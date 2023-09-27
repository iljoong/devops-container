FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
ARG BUILDID=0

WORKDIR /app
COPY --from=build-env /app/out .
ENV BUILDID=$BUILDID
ENTRYPOINT ["dotnet", "webapp.dll"]
