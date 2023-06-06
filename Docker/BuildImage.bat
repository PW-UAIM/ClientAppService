docker login -u majumi -p uaimrzadzi

docker rmi majumi/clientappservice:appservice

docker build -f ../majumi.CarService.ClientsAppService.Rest/Dockerfile.prod -t majumi/clientappservice:appservice ..

docker logout

pause