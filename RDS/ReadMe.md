Programı çalışır hale getirmek için:

1 - Amazon tarafında freetier bir mysql db oluşturulmalıdır.
    Oluşturma adımlarında yeni bir vpc tanımlanmalı ve bu vpc ye RDS erişimi için "MYSQL/Aurora" seçimi ile 3306 portunda "Anywhere" erişim verilmeli.
    Oluşturma sırasında "Public access" seçimi işaretlenmeli.

2 - RDS tarafında oluşturduğunuz MySQL veritanını bilgilerini appsettings.json içerisine eklemelisiniz.
    "ConnectionStrings": {
       "NorthwindDB": "Server=your_azure_rds_endpoint;Database=your_database_name;UserId=your_username;Password=your_password"
    }

3 - MySQL bağlantısına bağlanmak için MySQL Benchmark kullanabilirsiniz.
    Veritabanına bağlandıktan sonra aşağıdaki script ile şema ve tablo oluşturunuz.
        CREATE SCHEMA `nortshtar`;     
    
        CREATE TABLE `person` (
          `IdPerson` int NOT NULL,
          `Name` varchar(45) DEFAULT NULL,
          `Surname` varchar(45) DEFAULT NULL,
          `Mail` varchar(45) DEFAULT NULL,
          `Phone` varchar(45) DEFAULT NULL,
          PRIMARY KEY (`IdPerson`),
          UNIQUE KEY `IdPerson_UNIQUE` (`IdPerson`)
        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci

4 - RDS servislerini direk RDS > Controllers > RDSController içinde bulabilirsiniz.
    
    * PUT PERSON
        https://localhost:7233/RDS/insertperson
        {
          "idPerson": 7,
          "name": "Arthem ",
          "surname": "Tayh",
          "mail": "arthemt@gmail.com",
          "phone": "75323457"
        }

    * GET PERSON BY ID
        https://localhost:7233/RDS/getpersonbyid?id=1

    * GET ALL PERSON
        https://localhost:7233/RDS/getpersons 

    * DELETE PERSON BY ID
        https://localhost:7233/RDS/deleteperson?id=1