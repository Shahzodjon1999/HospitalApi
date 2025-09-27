# 1-qadam: build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Solution va project fayllarni nusxalash
COPY Hospital.sln .
COPY Hospital.Api/Hospital.Api.csproj ./Hospital.Api/
COPY Hospital.Application/Hospital.Application.csproj ./Hospital.Application/
COPY Hospital.Domen/Hospital.Domen.csproj ./Hospital.Domen/
COPY Hospital.Infrastructure/Hospital.Infrastructure.csproj ./Hospital.Infrastructure/
COPY Hospital.NUnitTesting/Hospital.NUnitTesting.csproj ./Hospital.NUnitTesting/
COPY Hospital.XUnitTesting/Hospital.XUnitTesting.csproj ./Hospital.XUnitTesting/
COPY Hospital.MSTesting/Hospital.MSTesting.csproj ./Hospital.MSTesting/

# NuGet paketlarini yuklash
RUN dotnet restore Hospital.Api/Hospital.Api.csproj

# Barcha fayllarni nusxalash
COPY . .

# Loyihani publish qilish Сборка
RUN dotnet publish Hospital.Api/Hospital.Api.csproj -c Release -o /app/publish

# 2-qadam: runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
ENTRYPOINT ["dotnet", "Hospital.Api.dll"]
