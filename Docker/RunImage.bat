docker login -u majumi -p uaimrzadzi

docker ps -a

docker stop clientappservice

docker ps 

docker images

::docker pull majumi/clientappservice:appservice

docker run --name clientappservice -p 5010:5010 -it majumi/clientappservice:appservice

pause

docker stop clientappservice

docker rm clientappservice

pause
