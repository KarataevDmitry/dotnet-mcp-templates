using System.Text.Json;

namespace AIGuiders.SampleMcp.Tests;

public sealed class McpToolManifestTests
{
    [Fact]
    public void Mcp_tools_manifest_matches_ToolCatalog_names_and_descriptions()
    {
        var manifestPath = Path.Combine(AppContext.BaseDirectory, "mcp-tools.manifest.json");
        Assert.True(File.Exists(manifestPath), $"Missing copied manifest: {manifestPath}");

        using var doc = JsonDocument.Parse(File.ReadAllText(manifestPath));
        Assert.True(doc.RootElement.TryGetProperty("schemaVersion", out _), "Missing schemaVersion");
        Assert.True(doc.RootElement.TryGetProperty("mcpId", out var mcpId), "Missing mcpId");
        Assert.Equal("sample-mcp", mcpId.GetString());

        var toolsEl = doc.RootElement.GetProperty("tools");
        Assert.Equal(JsonValueKind.Array, toolsEl.ValueKind);

        var manifest = toolsEl
            .EnumerateArray()
            .Select(t => (Name: t.GetProperty("name").GetString()!, Description: t.GetProperty("description").GetString()))
            .ToDictionary(t => t.Name, t => t.Description, StringComparer.Ordinal);

        var catalog = ToolCatalog.Build()
            .ToDictionary(t => t.Name!, t => t.Description, StringComparer.Ordinal);

        Assert.Equal(catalog.Count, manifest.Count);
        foreach (var (name, expectedDesc) in catalog)
        {
            Assert.True(manifest.TryGetValue(name, out var actualDesc), $"Missing tool in manifest: {name}");
            Assert.Equal(expectedDesc, actualDesc);
        }
    }
}

