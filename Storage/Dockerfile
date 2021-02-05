FROM mcr.microsoft.com/dotnet/sdk as base
WORKDIR /workspace

COPY FakeWebcomic.Storage .
RUN dotnet publish -c Release -o storage FakeWebcomic.Storage.csproj

FROM mcr.microsoft.com/dotnet/aspnet
COPY --from=base workspace/storage .
CMD [ "dotnet", "FakeWebcomic.Storage.dll" ]
