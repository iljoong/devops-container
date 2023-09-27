# Sample code for DevOps HoL (Container)

![DevOps pipeline](./devops_pipeline.png)

## Local build & test

Build and run a container in local environment.

```
docker build -t webapp:latest -f ./src/Dockerfile ./src

docker run --name webapp --rm -e BUILDID=001 -e APP_ENVIRONMENT=Dev -p 5000:80 -d webapp:latest
```

### ACR build

Build a container using ACR and push to your repository.

```
az acr build -r ikjcontainer.azurecr.io -f Dockerfile --build-arg BUILDID=1 -t <youracr>.azurecr.io/webapp:1  -t <youracr>.azurecr.io/webapp:latest .

docker run --name webapp --rm -p 8081:80 -d <youracr>.azurecr.io/webapp:1
```

## Pipelines

Create a build and release pipeline in Azure DevOps. See [sample pipelines](./pipelines)

## AKS deployment & troubleshooting

Create a secret in your namespace before deploy to AKS.

```
kubectl create secret docker-registry regsecret \
--docker-server=<youracr>.azurecr.io \
--docker-username=<youracr> \
--docker-password=<password> \
--namespace qa
```

Command to Get IP of the service and others

```
kubectl get svc -n qa

kubectl describe pod <podname> -n qa
```

## References

- Containerize a .NET app
    - https://learn.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=linux&pivots=dotnet-7-0

- Azure DevOps (yaml)
    - yaml schema: https://learn.microsoft.com/en-us/azure/devops/pipelines/yaml-schema/?view=azure-pipelines
    - pipeline task: https://learn.microsoft.com/en-us/azure/devops/pipelines/tasks/reference/?view=azure-pipelines&viewFallbackFrom=azure-devops
    - K8s manifest task: https://learn.microsoft.com/en-us/azure/devops/pipelines/tasks/reference/kubernetes-manifest-v0?view=azure-pipelines&viewFallbackFrom=azure-devops
    - pre-defiend variables: https://learn.microsoft.com/en-us/azure/devops/pipelines/build/variables?view=azure-devops&tabs=yaml
