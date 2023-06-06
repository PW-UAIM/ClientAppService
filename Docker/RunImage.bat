docker login -u majumi -p uaimrzadzi

docker stop clientappservice

docker pull majumi/clientappservice:appservice

<<<<<<< HEAD
=======
docker images

::docker pull majumi/clientappservice:appservice

>>>>>>> cdfe589504cf79287387589f24e689b9dcbe9551
docker run --name clientappservice -p 5010:5010 -it majumi/clientappservice:appservice

pause

docker stop clientappservice

docker rm clientappservice

pause