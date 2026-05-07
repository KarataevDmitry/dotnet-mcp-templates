## AIGuiders.DotnetMcp.Templates

Template pack for `dotnet new` to bootstrap MCP servers on .NET.

### nuget.org publishing (later)

This repo is configured for **Trusted Publishing** (OIDC) — no long-lived API keys.

1) On `nuget.org`: **Trusted publishing** → add policy for GitHub Actions:
- **Repository owner**: `KarataevDmitry`
- **Repository**: `dotnet-mcp-templates`
- **Workflow file**: `publish.yml`
- **Environment**: (leave empty)

2) Create a tag like `v0.1.5` and push it — workflow publishes the package.

### Install

```powershell
dotnet new install AIGuiders.DotnetMcp.Templates
```

### Create a new MCP server (full pattern)

```powershell
dotnet new mcp -n MyCompany.MyMcp --mcp-id my-mcp
```

### Create a minimal MCP server

```powershell
dotnet new mcp-min -n MyCompany.MyMcp --mcp-id my-mcp
```

### Uninstall

```powershell
dotnet new uninstall AIGuiders.DotnetMcp.Templates
```

