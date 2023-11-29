using FirebaseAdmin;
using Newtonsoft.Json;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using System;
using System.IO;

namespace UI
{
    public static class FirebaseService
    {
        static string firebaseConfig = "";
        static FirebaseService()
        {
            string exePath = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFilePath = Path.Combine(exePath, "Firebase", "Credentials.json");
            firebaseConfig = File.ReadAllText(jsonFilePath);
        }

        static string filepath = "";
        public static FirestoreDb Database { get; private set; }

        public static void SetEnvironmentVariable()
        {
            filepath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName())) + ".json";
            File.WriteAllText(filepath, firebaseConfig);
            File.SetAttributes(filepath, FileAttributes.Hidden);
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            Database = FirestoreDb.Create("local-church-e9acb");
            File.Delete(filepath);
        }
    }
}
