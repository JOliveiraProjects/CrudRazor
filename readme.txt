Execute o script no SQL Server
Crie um usuario para o banco
user id=vidalink;
password=vidalink1234;

<connectionStrings>
    <add name="VidalinkDB" connectionString="metadata=res://*/Data.Vidalink.csdl|res://*/Data.Vidalink.ssdl|res://*/Data.Vidalink.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.\SQLEXPRESS;initial catalog=Vidalink;persist security info=True;user id=vidalink;password=vidalink1234;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
</connectionStrings>

crie no IIS uma aplicação
Aponte para o ambiente "pasta do arquivo".