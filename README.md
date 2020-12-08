# SmartSchool
Teste

# Call

curl --request GET \
  --url http://localhost:5000/api/cliente
  
curl --request PUT \
  --url http://localhost:5000/api/cliente/DE8AD240-FAD6-44BD-B6A2-2C6994714C65 \
  --header 'Content-Type: application/json' \
  --data '{
	"id": "DE8AD240-FAD6-44BD-B6A2-2C6994714C65",
  "nome": "Marta",
	"idade": 42
}'

curl --request POST \
  --url http://localhost:5000/api/cliente \
  --header 'Content-Type: application/json' \
  --data '{
	"nome": "Juliana Jose",
	"idade": 36
}'

curl --request GET \
  --url http://localhost:5000/api/cliente/byid/89565508-0A7E-4A77-BFAA-EA7B7882087C
  
 curl --request DELETE \
  --url http://localhost:5000/api/cliente/19ED13C9-45B7-4CD7-A0B2-D8B4FBEBCA26
