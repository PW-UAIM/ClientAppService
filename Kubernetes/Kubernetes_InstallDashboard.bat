kubectl apply -f https://raw.githubusercontent.com/kubernetes/dashboard/v2.5.0/aio/deploy/recommended.yaml

kubectl -n kube-system get all

kubectl -n kubernetes-dashboard get all

::Be careful!!!
::kubectl edit deployment kubernetes-dashboard -n kubernetes-dashboard

::kubectl patch deployment kubernetes-dashboard -n kubernetes-dashboard --type 'json' -p '[{"op": "add", "path": "/spec/template/spec/containers/0/args/-", "value": "--enable-skip-login"}]'

kubectl -n kubernetes-dashboard create serviceaccount cluster-admin-dashboard-sa
::kubectl -n kubernetes-dashboard delete serviceaccount cluster-admin-dashboard-sa

kubectl -n kubernetes-dashboard create clusterrolebinding cluster-admin-dashboard-sa --clusterrole=cluster-admin --serviceaccount=kubernetes-dashboard:cluster-admin-dashboard-sa
::kubectl -n kubernetes-dashboard delete clusterrolebinding cluster-admin-dashboard-sa

kubectl -n kubernetes-dashboard get secrets

kubectl -n kubernetes-dashboard create -f dashboard_sa_secret.yaml
::kubectl -n kubernetes-dashboard delete -f dashboard_sa_secret.yaml

kubectl -n kubernetes-dashboard get secrets

kubectl -n kubernetes-dashboard describe secret cluster-admin-dashboard-sa-secret

pause
