echo off
set url=https://localhost:5010

CALL:curl_test "Poprawne logowanie" GET /client/1/login

CALL:curl_test "Niepoprawne logowanie" GET /client/2000/login

echo Nazwa testu: "Dodaj samochod"
echo Testowany url: https://localhost:5010/car/add
curl -X POST https://localhost:5010/car/add -H "Content-Type: application/json" -d ^
"{^
	\"CarID\": -1,^
	\"Make\": \"Renault\",^
	\"Model\": \"Megan\",^
	\"Year\": 2020,^
	\"Mileage\": 20000,^
	\"EngineSize\": \"3.5\",^
	\"VIN\": \"YV4A22RK1M1234567\",^
	\"LicensePlate\": \"PY21ZSL\",^
	\"ClientID\": 1^
}"
echo:
echo:

echo Nazwa testu: "Dodawanie wizyty"
echo Testowany url: https://localhost:5010/visit/add
curl -X POST https://localhost:5010/visit/add -H "Content-Type: application/json" -d ^
"{^
	\"visitID\": -1,^
  	\"clientID\": 1,^
  	\"serviceType\": \"string\",^
  	\"serviceDate\": \"2023-04-14T15:48:11.742Z\",^
  	\"serviceCost\": 0,^
  	\"serviceStatus\": \"string\",^
  	\"notes\": \"string\",^
  	\"mechanicID\": 2,^
  	\"carID\": 3^
}"

echo:
echo:
CALL:curl_test "Wszystkie samochody klienta o ID = 1" GET /car/client/1

CALL:curl_test "Wszystkie wizyty klienta o ID = 1" GET /visit/client/1

CALL:curl_test "Wizyta o ID 1" GET /visit/1

CALL:curl_test "Samochod o ID 1" GET /car/1

EXIT /B 0

:curl_test
echo Nazwa testu: %~1
echo Testowany url: %url%%~3
curl -X %~2 ^
	 %url%%~3 ^
	 -H 'accept:application/json'
echo:
echo:
EXIT /B 0
