# .Net Backend Project
## _Enoca Company Order Managementr_

## Contents

- .NET Core 6 API
- MSSQL
- Swagger UI
- Entity Framework Code First
- Repository Design Pattern (AsyncGenericRepositroy and GenericRepository)
- CQRS Design Pattern 
- Onion Architecture
- IoC
- Fluent Validation
- Dynamic Search (Comprehensive Output "GetList")
- Business Rules (Comprehensive Business)
- CRUD Operations (CRUD Operations)
- Pagging (Comprehensive Pagging Properties - Page Size, Page)
- Exceptions (Detailed Error Throwing) - Middleware
- Handler Structure 
- BaseController - BaseEntity 
- SOLID
- N-Tier Architecture
- Password Hashing-Salt
- Json Web Token 


İçerikte 18 adet metot vardır. Hepsi CQRS yapısıyla hazırlandı. 
Hepsinin iş kuralları ince detayına kadar yazıldı.
Validation kuralları her Command'a eklendi.
İsterlerin hepsi yapıldı, onun dışında eklenen bir çok şey var.
Build edilip push edilmiştir. Kesinlikle hatası yoktur.
Üzerinde çok test yapmaya vaktim yoktu, bir kaç bulgu çıkma ihtimali vardır.
Herhangi bir bug çıkması halinde düzeltilebilir.

<br/>
<br/>
<br/>

Örnek TimeSpan girişi. Saat değerleri TimeSpan ile tutuldu.

{
  "name": "Enoca",
  "status": true,
  "orderStartDate": "09:30:00.0000000",
  "orderFinishDate":"20:30:00.0000000"
}

Örnek Dynamic Search Girişi : 

{
  "sort": [
    {
      "field": "Name",
      "dir": "asc"
    }
  ],
  "filter": {
    "field": "Name",
    "operator": "eq",
    "value": "Iphone 11",
    "logic": "or",
    "filters": [
    { "field": "price",
    "operator": "gte",
    "value": "30000"}
    ]
  }
}
