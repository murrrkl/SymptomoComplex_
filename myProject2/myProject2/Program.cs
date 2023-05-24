using MySql.Data.MySqlClient;
using Microsoft.AspNetCore;
using myProject2;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;



namespace myProject2
{
    public class Program
    {

        public static void Main(string[] args)
        {
            SymptomoComplex();

            CreateWebHostBuilder(args).Build().Run();

        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();


        public static void get_symtoms(ref List<string> a, ref List<string> patients, int i, char f, char s, ref int FeaturesNum)
        {
            a.Clear();
            string current = patients[i];
            string new_symptom = "";
            FeaturesNum = 0;

            // Для текущего
            foreach (char c in current)
            {

                if (c.Equals(f) == true)
                {
                    new_symptom += c;
                    a.Add(new_symptom);
                    FeaturesNum++;
                    new_symptom = "";
                }

                if (c.Equals(s) == false && c.Equals(f) == false)
                {
                    new_symptom += c; // формирую пару: симтом: значение
                }

            }
        }


        public static void get_three_symptoms(ref List<string> a, ref List<string> b, ref List<string> complex, ref List<string> patients, ref int FeaturesNum, ref List<int> complex_count, int i, int N, int Percent, char f, char s)
        {
            // Для 3х симтомов 
            for (int k = 0; k < FeaturesNum - 2; k++)
            {
                for (int k1 = k + 1; k1 < FeaturesNum - 1; k1++)
                {
                    for (int k2 = k1 + 1; k2 < FeaturesNum; k2++)
                    {
                        int counter_complex = 1;

                        for (int j = i + 1; j < N; j++)
                        {
                            get_symtoms(ref b, ref patients, j, f, s, ref FeaturesNum);

                            // ПОИСК СИМПТОМА КОМПЛЕКСА
                            if (b.Contains(a[k]) && b.Contains(a[k1]) && b.Contains(a[k2]))
                            {
                                counter_complex++;
                            }

                        } // Цикл для следующего

                        if ((Convert.ToDouble(counter_complex) / Convert.ToDouble(N) * 100) >= Percent)
                        {
                            string str = a[k] + " " + a[k1] + " " + a[k2];

                            if (!complex.Contains(str))
                            {
                                complex.Add(str); // Добавляю симптома комплекс
                                complex_count.Add(counter_complex);
                            }
                        }
                    }

                }
            }

        }

        public static void get_four_symptoms(ref List<string> a, ref List<string> b, ref List<string> complex, ref List<string> patients, ref int FeaturesNum, ref List<int> complex_count, int i, int N, int Percent, char f, char s)
        {
            // Для 4х симтомов 
            for (int k = 0; k < FeaturesNum - 3; k++)
            {
                for (int k1 = k + 1; k1 < FeaturesNum - 2; k1++)
                {
                    for (int k2 = k1 + 1; k2 < FeaturesNum - 1; k2++)
                    {
                        for (int k3 = k2 + 1; k3 < FeaturesNum; k3++)
                        {
                            int counter_complex = 1;

                            for (int j = i + 1; j < N; j++)
                            {
                                get_symtoms(ref b, ref patients, j, f, s, ref FeaturesNum);

                                // ПОИСК СИМПТОМА КОМПЛЕКСА
                                if (b.Contains(a[k]) && b.Contains(a[k1]) && b.Contains(a[k2]) && b.Contains(a[k3]))
                                {
                                    counter_complex++;
                                }

                            } // Цикл для следующего

                            if ((Convert.ToDouble(counter_complex) / Convert.ToDouble(N) * 100) >= Percent)
                            {
                                string str = a[k] + " " + a[k1] + " " + a[k2] + " " + a[k3];

                                if (!complex.Contains(str))
                                {
                                    complex.Add(str); // Добавляю симптома комплекс
                                    complex_count.Add(counter_complex);
                                }
                            }
                        }

                    }
                }
            }

        }

        public static void get_five_symptoms(ref List<string> a, ref List<string> b, ref List<string> complex, ref List<string> patients, ref int FeaturesNum, ref List<int> complex_count, int i, int N, int Percent, char f, char s)
        {
            // Для 5х симтомов 

            for (int k = 0; k < FeaturesNum - 4; k++)
            {
                for (int k1 = k + 1; k1 < FeaturesNum - 3; k1++)
                {
                    for (int k2 = k1 + 1; k2 < FeaturesNum - 2; k2++)
                    {
                        for (int k3 = k2 + 1; k3 < FeaturesNum - 1; k3++)
                        {
                            for (int k4 = k3 + 1; k4 < FeaturesNum; k4++)
                            {
                                int counter_complex = 1;

                                for (int j = i + 1; j < N; j++)
                                {
                                    get_symtoms(ref b, ref patients, j, f, s, ref FeaturesNum);

                                    // ПОИСК СИМПТОМА КОМПЛЕКСА
                                    if (b.Contains(a[k]) && b.Contains(a[k1]) && b.Contains(a[k2]) && b.Contains(a[k3]) && b.Contains(a[k4]))
                                    {
                                        counter_complex++;
                                    }

                                } // Цикл для следующего

                                if ((Convert.ToDouble(counter_complex) / Convert.ToDouble(N) * 100) >= Percent)
                                {
                                    string str = a[k] + " " + a[k1] + " " + a[k2] + " " + a[k3] + " " + a[k4];

                                    if (!complex.Contains(str))
                                    {
                                        complex.Add(str); // Добавляю симптома комплекс
                                        complex_count.Add(counter_complex);
                                    }
                                }
                            }

                        }
                    }
                }
            }

        }


        public static void SymptomoComplex()
        {
            dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText("patient_data.json"));

            string place = jsonFile[0]["doctor"]["place"]; // Место
            string data = jsonFile[0]["patient"]["data"]; // Дата

            List<string> patients = new List<string> { };

            for (int i = 0; i < jsonFile.Count; i++)
            {
                string record = JsonConvert.SerializeObject(jsonFile[i]["records"][0]); //  Симптомы
                record = record.Insert(record.Length - 1, ",");   
                patients.Add(record);
            }

            int N = jsonFile.Count; // Общее количество пациентов
            int Percent = 30; // Процент

            List<string> complex = new List<string> { };
            List<int> complex_count = new List<int> { };
            int counter_complex = 1;

            List<string> a = new List<string> { };
            List<string> b = new List<string> { };

            char f = char.Parse(",");
            char s = char.Parse("{");

            string FinalText = "";

            int FeaturesNum = 0;            

            for (int i = 0; i < N - 1; i++)
            {
              
                get_symtoms(ref a, ref patients, i, f, s, ref FeaturesNum);

                get_three_symptoms(ref a, ref b, ref complex, ref patients, ref FeaturesNum, ref complex_count, i, N, Percent, f, s);
                get_four_symptoms(ref a, ref b, ref complex, ref patients, ref FeaturesNum, ref complex_count, i, N, Percent, f, s);
                get_five_symptoms(ref a, ref b, ref complex, ref patients, ref FeaturesNum, ref complex_count, i, N, Percent, f, s);

            } // Цикл для текущего

            // Запись в файл

            double percent = 0;
            FinalText += "[";
            FinalText += "\n";

            for (int j = 0; j < complex.Count; j++)
            {

                percent = (Convert.ToDouble(complex_count[j]) / Convert.ToDouble(N)) * 100;
                FinalText += "{\n";
                FinalText += "\"symptoms\"";
                FinalText += " : {\n";
                complex[j] = complex[j][..^1];
                FinalText += complex[j];
                FinalText += "\n";
                FinalText += "},";
                FinalText += "\n";
                FinalText += "\"percent_people\"";
                FinalText += " : ";
                FinalText += percent.ToString();
                FinalText += ", \n";
                FinalText += "\"total_number_people\"";
                FinalText += " : ";
                FinalText += N.ToString();
                FinalText += ", \n";
                FinalText += "\"place\"";
                FinalText += " : ";
                FinalText += "\"";
                FinalText += place;
                FinalText += "\"";
                FinalText += ",\n";
                FinalText += "\"date_symptoms\"";
                FinalText += " : ";
                FinalText += "\"";
                FinalText += data;
                FinalText += "\"";
                FinalText += "\n";
                FinalText += "}";

                if (j != complex.Count - 1)
                {
                    FinalText += ",";
                }

                FinalText += "\n";
            }
            FinalText += "]";

            string path = @"symptomocomplex.json";

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(FinalText);
            }

        } // Закрываю метод SqlTask 

    }

}

