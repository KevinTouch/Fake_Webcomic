FROM mcr.microsoft.com/dotnet/sdk as base
WORKDIR /workspace

COPY FakeWebcomic.Client .
RUN dotnet publish -c Release -o mvc FakeWebcomic.Client.csproj

FROM mcr.microsoft.com/dotnet/aspnet
COPY --from=base workspace/mvc .
CMD [ "dotnet", "FakeWebcomic.Client.dll" ]
