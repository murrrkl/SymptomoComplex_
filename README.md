# SymptomoComplex

Для чтения json файла необходимо установить NuGet пакет Newtonsoft.Json версии 12.0.3

Метод SymptomoComplex() в файле Program.cs отвечает за формирование симптомокомлексов на основе описания симптомов пациентов.
Пример описаний симтомов пациентов подаётся в файле patient_data.json от 1-ой команды. Для объединения с 1 командой метод SymptomoComplex() нужно вызвать сразу после формирования выходного файла от 1 команды.

Результатом работы метода SymptomoComplex() является файл с симптомокомплексами symptomocomplex.json (пример представлен), который подаётся на вход 3-ей команде.

Для компиляции и запуска кода использовалась Visual Studio.

# Фрагмент входного файла patient_data.json
```
[
  {
    "doctor": {
      "id": 1,
      "name": "Иванов Иван Иванович",
      "place": "Владивостокская городская поликлиника №4"
    },

    "patient": {
      "ID": 123,
      "name": "Мерзляков Даниил Витальевич",
      "date_of_birth": "11.11.1988",
      "sex": "m",
      "data": "01.01.2023"
    }
]
```
# Фрагмент выходного файла symptomocomplex.json
```
[
{
"symptoms" : {
  "головная боль":"сильная", 
  "кашель":"есть", 
  "температура":"повышенная"
},
"percent_people" : 50, 
"total_number_people" : 10, 
"date_symptoms" : "2023-01-01T00:00:00",
"hospital" : "Владивостокская городская поликлиника №4"
},
{
"symptoms" : {
  "головная боль":"сильная", 
  "кашель":"есть", 
  "насморк":"есть"
},
"percent_people" : 30, 
"total_number_people" : 10, 
"date_symptoms" : "2023-01-01T00:00:00",
"hospital" : "Владивостокская городская поликлиника №4"
}
]

```
