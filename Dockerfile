FROM microsoft/aspnetcore:2.0-stretch AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-stretch AS build
WORKDIR /src
COPY ["ShoeStore.Products.AspNetCore/ShoeStore.Products.AspNetCore.csproj", "ShoeStore.Products.AspNetCore/"]
COPY ["ShoeStore.Products.Infrastructure/ShoeStore.Products.Infrastructure.csproj", "ShoeStore.Products.Infrastructure/"]
COPY ["ShoeStore.Products.Domain/ShoeStore.Products.Domain.csproj", "ShoeStore.Products.Domain/"]
COPY ["ShoeStore.Products.Tasks/ShoeStore.Products.Tasks.csproj", "ShoeStore.Products.Tasks/"]
RUN dotnet restore "ShoeStore.Products.AspNetCore/ShoeStore.Products.AspNetCore.csproj"
COPY . .
WORKDIR "/src/ShoeStore.Products.AspNetCore"
RUN dotnet build "ShoeStore.Products.AspNetCore.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ShoeStore.Products.AspNetCore.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ShoeStore.Products.AspNetCore.dll"]