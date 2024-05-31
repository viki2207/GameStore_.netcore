$sa_password = "sa"
dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Server=KIVI\SQLEXPRESS;Database=GameStore;User Id=sa;Password=$sa_password;TrustServerCertificate=True;"
  