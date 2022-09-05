# itau-od5-dep-od5.environments

Biblioteca para auxiliar nas configurações segregadas por ambiente, podendo utilizar arquivo .config adicional.

## Como utilizar

**Passo 1:** No arquivo .config da aplicação, informe as informações da biblioteca para carrega-la e ter acesso a config personalizada.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="environmentSettings" type="Qualita.Util.Environments.EnvironmentSettingsSection, Qualita.Util.Environments"/>
  </configSections>
  ...
<configuration>
```

**Passo 2:** Agora crie as chaves/valores necessarias pra a _section_ **_environmentSettings_**, declarado no **passo 1**.

A propriedade obrigatória _useEnvironKey_ irá definir qual a chave deverá ser utilizada, ela pode ser alterada em tempo de execução.
A estrutura de preenchimento é:
`<environmentSettings useEnvironKey='?'><environ key='?'><add key='?' value='?'/>...`

Use a propriedade _file_ do elemento _environ_ para definir um arquivo externo.
**Observação:**
O elemento _environ_ dever ser declarodo novamente no arquivo externo e com o mesmo valor de _key_, a propriedade _name_ é opcional.
Todos os arquivos externos devem existir mesmo se não for ativado pela propriedade _activeEnviron_ do elemento principal.

_Exemplo App.config:_

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="environmentSettings" type="Qualita.Util.Environments.EnvironmentSettingsSection, Qualita.Util.Environments"/>
  </configSections>
 
  <environmentSettings useEnvironKey="loc">

    <environ key="loc" name="Local">
      <add key="URL" value="http://localhost:8080"/>
      <add key="DIR_EXPORT" value="D:\TEMP"/>
    </environ>

    <environ key="1" file="dev.config" />
    <environ key="2" file="homolog.config" />
    <environ key="3" file="prod.config" />

  </environmentSettings>

<configuration>
```

_Exemplo arquivo externo dev.config:_

```xml
<?xml version="1.0" encoding="utf-8" ?>
<environ key="1" name="Desenvolvimento">
    <add key="URL" value="http://app.develop"/>
    <add key="DIR_EXPORT" value="D:\APP\EXPORT"/>
</environ>
```
