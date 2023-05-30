docker login -u majumi -p uaimrzadzi

docker rmi majumi/clientappservice:appservice

docker build -f ../majumi.CarService.ClientsAppService.Rest/Dockerfile.prod -t majumi/clientappservice:appservice ..

docker images

docker image ls --filter label=stage=zsutpwpatterns-webapplication_build

docker image prune --filter label=stage=zsutpwpatterns-webapplication_build --force

docker push majumi/clientappservice:appservice

docker images

docker logout

pause
