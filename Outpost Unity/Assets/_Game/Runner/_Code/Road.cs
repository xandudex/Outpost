using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Splines;
using VContainer;

namespace MysteryFoxes.Outpost.Runner
{
    public class Road : MonoBehaviour
    {
        [BoxGroup(GroupID = "1")]
        [Header("Road Spline Setup")]
        [SerializeField]
        SplineContainer roadSpline;

        [BoxGroup(GroupID = "1")]
        [SerializeField]
        Vector3 startPoint;

        [BoxGroup(GroupID = "1")]
        [SerializeField]
        Vector3 endPoint;
        [BoxGroup(GroupID = "1")]

        [SerializeField]
        float offset;

        [BoxGroup(GroupID = "1")]
        [SerializeField]
        float period;

        [BoxGroup(GroupID = "2")]
        [Header("Mesh Generation")]
        [SerializeField]
        Material roadMaterial;

        [BoxGroup(GroupID = "2")]
        [SerializeField]
        float density;

        [BoxGroup(GroupID = "2")]
        [SerializeField]
        float roadWidth;

        [BoxGroup(GroupID = "3")]
        [Header("Player View Generation")]
        [SerializeField]
        float distanceToDraw;

        [BoxGroup(GroupID = "3")]
        [SerializeField]
        float borderWidth;

        [BoxGroup(GroupID = "4")]
        [Header("Prefabs")]
        [SerializeField]
        GameObject gasStationPrefab;

        Vehicle vehicle;
        List<RoadData> roadsData = new();

        [Inject]
        void Construct(Vehicle vehicle)
        {
            this.vehicle = vehicle;

            GenerateSpline();
            GenerateMesh();
        }

        private void Update()
        {
            if (vehicle == null) return;

            UpdatePlayerPosition(vehicle.transform.position);
        }

        void GenerateSpline()
        {
            Spline spline = roadSpline.AddSpline();

            BezierKnot startKnow = new BezierKnot
            {
                Position = startPoint,
            };

            BezierKnot endKnow = new BezierKnot
            {
                Position = endPoint,
            };

            spline.Add(startKnow);
            spline.Add(endKnow);

            float roadLinearLength = Vector3.Distance(startPoint, endPoint);
            int knotsCount = (int)(roadLinearLength / period);
            Vector3 direction = (endPoint - startPoint).normalized;
            direction = Vector3.Cross(Vector3.up, direction);

            for (int i = 1; i < knotsCount; i++)
            {
                float offset = Random.Range(-this.offset, this.offset);
                Vector3 position = Vector3.Lerp(startPoint, endPoint, (float)i / knotsCount);
                position += direction * offset;
                BezierKnot knot = new BezierKnot()
                {
                    Position = position,
                };

                spline.Insert(i, knot);

                if (i % 2 == 0)
                {
                    GenerateGasStations(spline.ElementAt(i - 1), knot);
                }
            }

            var all = new SplineRange(0, spline.Count);
            spline.SetTangentMode(all, TangentMode.AutoSmooth);

            void GenerateGasStations(BezierKnot enterKnot, BezierKnot exitKnot)
            {
                var startPoint = new Vector3(enterKnot.Position.x, enterKnot.Position.y, enterKnot.Position.z);
                var endPoint = new Vector3(exitKnot.Position.x, exitKnot.Position.y, exitKnot.Position.z);

                Vector3 direction = (endPoint - startPoint).normalized;
                direction = Vector3.Cross(Vector3.up, direction);

                float offset = Random.value > 0.5 ? this.offset : -this.offset;

                Spline spline = roadSpline.AddSpline();

                BezierKnot knot1 = new BezierKnot
                {
                    Position = Vector3.Lerp(startPoint, endPoint, .33f) + direction * offset,
                };
                BezierKnot knot2 = new BezierKnot
                {
                    Position = Vector3.Lerp(startPoint, endPoint, .66f) + direction * offset,

                };

                spline.Add(enterKnot);
                spline.Add(knot1);
                spline.Add(knot2);
                spline.Add(exitKnot);
                spline.SetTangentMode(new SplineRange(0, spline.Count), TangentMode.AutoSmooth);
            }
        }

        void GenerateMesh()
        {
            for (int j = 0; j < roadSpline.Splines.Count; j++)
            {
                var spline = roadSpline.Splines[j];

                float length = spline.GetLength();
                int segments = (int)(length / density);

                Mesh mesh = new Mesh();
                GameObject go = new GameObject();
                go.transform.SetParent(transform);

                MeshFilter meshFilter = go.AddComponent<MeshFilter>();
                MeshRenderer meshRenderer = go.AddComponent<MeshRenderer>();
                MeshCollider meshCollider = go.AddComponent<MeshCollider>();

                meshCollider.sharedMesh = mesh;
                meshFilter.sharedMesh = mesh;
                meshRenderer.sharedMaterial = roadMaterial;

                List<Vector3> vertices = new List<Vector3>();
                List<int> triangles = new List<int>();

                for (int i = 0; i <= segments; i++)
                {
                    spline.Evaluate((float)i / segments, out Unity.Mathematics.float3 fposition, out Unity.Mathematics.float3 ftangent, out Unity.Mathematics.float3 fupVector);
                    Vector3 position = fposition.ToVector();
                    Vector3 tangent = ftangent.ToVector();
                    Vector3 upVector = fupVector.ToVector();

                    Vector3 right = Vector3.Cross(upVector, tangent).normalized;

                    var verticeRight = position + right * roadWidth / 2f;
                    var verticeLeft = position - right * roadWidth / 2f;

                    vertices.Add(verticeLeft);
                    vertices.Add(verticeRight);

                    if (i == 0) continue;

                    triangles.Add(vertices.Count - 1);
                    triangles.Add(vertices.Count - 3);
                    triangles.Add(vertices.Count - 4);
                    triangles.Add(vertices.Count - 1);
                    triangles.Add(vertices.Count - 4);
                    triangles.Add(vertices.Count - 2);
                }
                mesh.SetVertices(vertices);
                mesh.SetTriangles(triangles, 0);

                roadsData.Add(new RoadData
                {
                    Spline = spline,
                    Mesh = mesh,
                });
            }
        }

        void GenerateGasStations()
        {

        }

        List<BoxCollider> colliders = new List<BoxCollider>();
        void PopulateBorders(float relativePosition)
        {
            Spline spline = roadSpline.Spline;

            float relativeDraw = distanceToDraw / spline.GetLength();
            float relativeSize = borderWidth / spline.GetLength();
            float countOfElements = relativeDraw / relativeSize;

            float relativeStart = relativePosition - relativeDraw / 2f;
            float relativeEnd = relativePosition + relativeDraw / 2f;

            while (colliders.Count < countOfElements)
            {
                GameObject gameObject = new GameObject("Border Collider");
                gameObject.transform.SetParent(transform);
                colliders.Add(gameObject.AddComponent<BoxCollider>());
            }

            for (int i = 0; i < countOfElements; i++)
            {
                float t = relativeStart + i * (relativeSize / 2);
                Vector3 position = spline.EvaluatePosition(t);
                Vector3 tangent = spline.EvaluateTangent(t);
                Vector3 upVector = spline.EvaluateUpVector(t);
                Vector3 right = Vector3.Cross(tangent, upVector).normalized;
                colliders[i].center = position + right * (roadWidth / 2f);
            }
        }

        void UpdatePlayerPosition(Vector3 position)
        {
            RoadData roadData = roadsData[0];
            float nearestPoint = SplineUtility.GetNearestPoint(roadData.Spline, position, out Unity.Mathematics.float3 nearest, out float t);
            PopulateBorders(nearestPoint);
        }
        private void OnDrawGizmos()
        {
            foreach (Spline spline in roadSpline.Splines)
            {
                float length = spline.GetLength();
                int segments = (int)(length / density);
                for (int i = 0; i <= segments; i++)
                {
                    spline.Evaluate((float)i / segments, out Unity.Mathematics.float3 fposition, out Unity.Mathematics.float3 ftangent, out Unity.Mathematics.float3 fupVector);
                    Vector3 position = fposition.ToVector();
                    Vector3 tangent = ftangent.ToVector();
                    Vector3 upVector = fupVector.ToVector();

                    Vector3 right = Vector3.Cross(upVector, tangent).normalized;

                    Gizmos.DrawSphere(position + right * roadWidth / 2f, 1f);
                    Gizmos.DrawSphere(position - right * roadWidth / 2f, 1f);
                }
            }
        }


        class RoadData
        {
            public Spline Spline;
            public Mesh Mesh;
        }
    }
}
