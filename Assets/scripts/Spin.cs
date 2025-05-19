using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class Spin : MonoBehaviour
    {
        public Transform target;

        public float duration1;
        public float duration2;

        public float minRotation;
        public float maxRotation;

        public float aShift;

        public int sectorNum = 12;

        public void Execute()
        {
            target.DOKill();

            var newRot = -UnityEngine.Random.Range(minRotation, maxRotation);
            var rot1 = new Vector3(0, 0, newRot);

            target.DORotate
                (
                    rot1,
                    UnityEngine.Random.Range(duration1, duration2),
                    RotateMode.LocalAxisAdd
                )
                .OnComplete(OnComplete)
                .Play();
        }

        private void OnComplete()
        {
            float angle = target.transform.localRotation.eulerAngles.z;
            angle += aShift;

            angle = angle % 360f;

            int sector = Mathf.FloorToInt(angle / (360f / sectorNum)) + 1;

            Debug.Log($"Угол: {angle}, Сектор: {sector}");
        }
    }
}