using System;
using System.Windows.Media.Media3D;

namespace MathMatrix
{
    public class Calculation
    {

        private static Quaternion EulerToQuaternion(double yaw, double pitch, double roll)
        {
            double cy = Math.Cos(yaw * 0.5);
            double sy = Math.Sin(yaw * 0.5);
            double cr = Math.Cos(roll * 0.5);
            double sr = Math.Sin(roll * 0.5);
            double cp = Math.Cos(pitch * 0.5);
            double sp = Math.Sin(pitch * 0.5);

            double w = cy * cr * cp + sy * sr * sp;
            double x = cy * sr * cp - sy * cr * sp;
            double y = cy * cr * sp + sy * sr * cp;
            double z = sy * cr * cp - cy * sr * sp;

            return new Quaternion(x, y, z, w);
        }

        public static Matrix3D GetModificationMatrix(double yaw, double pitch, double roll, Point3D rotationPoint, Vector3D offset)
        {
            //On obtient la matrice identitaire (celle de base)
            Matrix3D modificationMatrix = Matrix3D.Identity;
            //On converti les degrés Euler en Quaternions
            Quaternion rotation = EulerToQuaternion(yaw * Math.PI/180, pitch * Math.PI / 180, roll * Math.PI / 180);

            //Si il y a une translation à faire, on la fait
            modificationMatrix.Translate(offset);
            //On applique la rotation
            modificationMatrix.RotateAt(rotation, rotationPoint);

            return modificationMatrix;
        }


    }
}