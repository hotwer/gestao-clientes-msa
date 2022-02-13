# Gestão de Clientes MSA

Ambos os projetos de _backend_ (Api) e _frontend_ (App) estão no mesmo repositório, a seguir as instruções para preparar o desenvolvimento de cada um deles

## Api

Desenvolvido usando .NET Core 5 e FluentNHibernate

### Passos
 - Habilitar servidor SQL Server (2014+)
 - Renomear o arquivo `example.appsettings.json` para `appsettings.json` (e criar arquivo `appsettings.Development.json`)
 - Nos arquivos `appsettings`, preencher a `ConnectionString.Default` do banco de dados preparado
 - Executar a migração `InitialMigration-*.sql` no caminho Api/GestaoClientesMSA/Database/Migrations
	- A migração já constroi o banco de dados (por padrão, mas você pode renomear _GestaoClientesMSA_))
 - Executar a seed de dados para inicialização do banco `ClientesSeed.sql` no caminho Api/GestaoClientesMSA/Database/Migrations/Seeds


## App

Desenvolvido usando _Vue_ 2.6^ com dependencia do *Vue Cli* e _bootstrap-vue_ 

### Instalar Vue Cli para comandos de build e serve
```
npm install -g @vue/cli
```

### Para instalar todas as dependencias 
```
npm install
```

### Gerar os arquivos e executar servidor local para desenvolvimento
```
npm run serve
```

### Minificar e gerar os arquivos de produção
```
npm run build
```

### Configurar rotas da API
No arquivo `axios.bootstrap.js` é configurado qual a rota ( _host_ ) principal da API, (ela deve se manter a mesma se o _launchSettins.json_ em `Api/Properties`)


