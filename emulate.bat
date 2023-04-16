echo off
set url=https://localhost:5010

echo "Klient loguje sie swoim identyfikatorem"
CALL:curl_test  GET /client/1/login
echo "Na stronie swojego profilu widzi auta" 
CALL:curl_test GET /car/client/1
echo "Moze na nim dodac nowe auto"
echo Testowany url: https://localhost:5010/car/add
curl -X POST https://localhost:5010/car/add -H "Content-Type: application/json" -d ^
"{^
	\"CarID\": 12,^
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
echo "Na panelu widzi takze swoje wizyty" 
CALL:curl_test GET /visit/client/1
echo "Moze tez sie zapisac na wizyte"
echo Testowany url: https://localhost:5010/visit/add
curl -X POST https://localhost:5010/visit/add -H "Content-Type: application/json" -d ^
"{^
  \"visitID\": 12,^
  \"clientID\": 1,^
  \"serviceType\": \"string\",^
  \"serviceDate\": \"2023-04-14T15:48:11.742Z\",^
  \"serviceCost\": 0,^
  \"serviceStatus\": \"string\",^
  \"notes\": \"string\",^
  \"mechanicID\": 0,^
  \"carID\": 12^
}"
echo:
echo:
echo "Oraz sprawdzic czy wszystkie dane sie zapisaly"
CALL:curl_test GET /car/client/1
CALL:curl_test GET /visit/client/1

EXIT /B 0

:curl_test
echo Testowany url: %url%%~2
curl -X %~1 ^
	 %url%%~2 ^
	 -H 'accept:application/json'
echo:
echo:
EXIT /B 0
