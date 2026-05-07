## AIGuiders.DotnetMcp.Templates

Template pack for `dotnet new` to bootstrap MCP servers on .NET.

### nuget.org publishing (later)

- Create an API key at `nuget.org` → **Account settings** → **API Keys**
- Add it as GitHub repo secret: `NUGET_API_KEY`
- Create a tag like `v0.1.5` and push it — workflow publishes the package

### Install

```powershell
dotnet new install AIGuiders.DotnetMcp.Templates
```

### Create a new MCP server (full pattern)

```powershell
dotnet new mcp -n MyCompany.MyMcp --mcp_id my-mcp
```

### Create a minimal MCP server

```powershell
dotnet new mcp-min -n MyCompany.MyMcp --mcp_id my-mcp
```

### Uninstall

```powershell
dotnet new uninstall AIGuiders.DotnetMcp.Templates
```

