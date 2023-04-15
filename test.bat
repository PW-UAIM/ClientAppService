echo off
set url=https://localhost:5010

CALL:curl_test "Poprawne logowanie" GET /client/1/login

CALL:curl_test "Niepoprawne logowanie" GET /client/2000/login

CALL:curl_test "Dodawanie samochodu" POST /car/add -d '{^
  "carID": 100,^
  "make": "string",^
  "model": "string",^
  "year": "2023-04-14T15:46:41.372Z",^
  "color": "string",^
  "mileage": 0,^
  "transmission": "string",^
  "fuelType": "string",^
  "engineSize": 0,^
  "horsepower": 0,^
  "torque": 0,^
  "drivetrain": "string",^
  "seatingCapacity": 0,^
  "vehicleType": "string",^
  "price": 0,^
  "location": "string"^
}'

CALL:curl_test "Dodawanie wizyty" POST /visit/add -d '{^
  "visitID": 100,^
  "clientID": 0,^
  "serviceType": "string",^
  "serviceDate": "2023-04-14T15:48:11.742Z",^
  "serviceTime": "string",^
  "serviceLocation": "string",^
  "serviceCost": 0,^
  "serviceStatus": "string",^
  "notes": "string",^
  "rating": 0,^
  "mechanicID": 0,^
  "carID": 0^
}'

CALL:curl_test "Wszystkie samochody klienta o ID = 1" GET /car/all/1

CALL:curl_test "Wszystkie wizyty klienta o ID = 1" GET /visit/all/1

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
