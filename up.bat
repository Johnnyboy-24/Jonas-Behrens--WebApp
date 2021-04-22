docker network create postgres-network
docker run --name postgres --hostname postgres -p5432:5432 -e POSTGRES_PASSWORD=mysecretpassword --net postgres-network -v database:/var/lib/postgresql/data/ -d postgres 
docker run --name pgadmin -p8080:80 -e PGADMIN_DEFAULT_EMAIL=admin@localhost -e PGADMIN_DEFAULT_PASSWORD=mysecretpassword --net postgres-network -v pgadmin-data:/var/lib/pgadmin/ -d dpage/pgadmin4
