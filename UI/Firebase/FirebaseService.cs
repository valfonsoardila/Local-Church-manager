using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using System;
using System.IO;

namespace UI
{
    public static class FirebaseService
    {
        static string fireconfig = @"
        {
          ""type"": ""service_account"",
          ""project_id"": ""local-church-e9acb"",
          ""private_key_id"": ""a042dafdd7e41c8b0e503e9cc8619fa4f0f8ef57"",
          ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQCl+fGjJC8Y6AOk\naF3LdXytxLA2woMKsUVXe1/63d5iqI3chHW35HXlNRgwKqAHapKk2tO9jfetAIJg\n8nGBWX6q5u3cUU2lZXN0dS2hV1DfEAyd2nzTDg1K+t3iSbmPlKNASjb3i0sVlSVV\nZZo5MOdRL3hbjRjgHhZnRS/iJ492BORArAsEWV+pEPjLW8i3iz1apWixXqs5VKrC\n3llb+eAq7O0NWkawVHWRmWpDvQB83e5zvp/k33eg7Vz7ihcPSMS4y6RU50C44ol3\nq+MJjfCGZ7pgFSw3yTdfJu+flR3uDfDuddDFupkM6mKNTuvBy4RwOZDw4jDjk6ro\n/rnf9S77AgMBAAECggEANXyD5ZZyBP0zu0YUv823JYpmXOc28nmpBmWQSxg3o6R8\nvs0C4IVjhr8i8daypmEuK6kHJiU7ZQlueo52jIAKJUnw6hhbRMsaNzPRxhYMzi1u\nW2o+4oa7Ouf4HAW1IjN8nmmsJ/6/7g8XrlrlJbwANzXse9hO5V5cyt/Na/xiq12o\nU91zx3Ik1Xxa92uaa38cteIhrB2nIM2Of6JKha68pCk2pQZ2l7mMcg31eGCxwyc1\nInPxNX0S09kzIvkz3nf1d2p5Y7LZLkHfNQGTS5m28h2welYDbPlnL3pXWaaHb3kV\niHkg+kmzo/gqxACvto4OT9QV6BwpndhBG8NiF+eVTQKBgQDOlSnPnwNUSzBjtPaP\nFJJPvdKQDozb8aQVLmdQffLrt/VvA0bo+PXuY2MEMJYEXPGyQ3ncV3UKaxkTRnkH\nbgOR5cS3peEmBYsjRQvsmtUu6nebGjeJ1mhhhMAEV1qRfWfVD+GmdCEQtJ4HYYCM\n3YvBs4NlAJBqHkGrh5arDPRTXQKBgQDNrhr6tfBfNzH9rjjvZCb+UOomLiiHrcsB\naRWtzgq1aAp+wfg38xDgK1QoHiT9OsdBRxMD6Y9YSJAM1L34V6089yl2B8GjMYNx\nb5SYVlVH2DwXrz5+eHjHigGAJXjF9N60PfeJt0jp0u2Ap6C5fBkO8Lt1tsDr+kZO\nlQgz7LX+NwKBgQCCUPplLMwu2peV7kwzCikaAIbZtTQKcy6s5e7qiek55XwAIbMT\nuCl7zlpiBDw+WFtntsUiyFDe15yj2irzEuVRnf4wU4XqNEkHYMEa6rlctS/qOemb\nHBQQoGt40ZoieVeMwk34cP2Cyk1+HnW3ZvKIqLNUfbycFKYcjJXxJWTjSQKBgHk9\nIqwcKOeHWpFlbCw4hf+s5IjC9qMbn6liLyQ3avqJrH4RimY4gf8Rq1bGhhk6148z\n/RJ2T0fD5h2aHazQyc5BBxCK++pdWlS4aAfwA+8ImEuBwj28d71vLPlDnVBayhfG\n2y4zeuhRrCwFI2mSrBaxcl6t7kRrT5wsnxw0cQa7AoGADIb4rOcMIEKgW8c+bo3+\nnSu2ZrANp7GoRzI8ePn6kN5m/4Wo9nXRRscmLcU+NP/MlCXxJZCyF9U2kzLxB/7z\nVkaGLe7ajjUdtFrTWjoDCHQhWb8F1CUGXerVTDIummHRUyKyN5MLJ6wP8V74QzuM\njT/anzOkV9iIS2AtGJAQPG8=\n-----END PRIVATE KEY-----\n"",
          ""client_email"": ""firebase-adminsdk-vt8vb@local-church-e9acb.iam.gserviceaccount.com"",
          ""client_id"": ""107946943507941427580"",
          ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
          ""token_uri"": ""https://oauth2.googleapis.com/token"",
          ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
          ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-vt8vb%40local-church-e9acb.iam.gserviceaccount.com"",
          ""universe_domain"": ""googleapis.com""
        }";
        static string filepath = "";
        public static FirestoreDb Database { get; private set; }

        public static void SetEnvironmentVariable()
        {
            filepath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName())) + ".json";
            File.WriteAllText(filepath, fireconfig);
            File.SetAttributes(filepath, FileAttributes.Hidden);
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            Database = FirestoreDb.Create("local-church-e9acb");
            File.Delete(filepath);
        }
    }
}
