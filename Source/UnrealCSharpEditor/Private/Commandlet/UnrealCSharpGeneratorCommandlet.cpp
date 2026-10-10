#include "Commandlet/UnrealCSharpGeneratorCommandlet.h"

#include "AssetRegistry/AssetRegistryModule.h"
#include "Modules/ModuleManager.h"
#include "UnrealCSharpEditor.h"

UUnrealCSharpGeneratorCommandlet::UUnrealCSharpGeneratorCommandlet()
{
	HelpDescription = TEXT("Generate UnrealCSharp C# bindings without launching the editor.");

	HelpUsage = TEXT("UnrealCSharpGenerator");

	HelpWebLink = TEXT("https://unrealcsharp.github.io");

	IsClient = false;
	IsEditor = true;
	IsServer = false;
	LogToConsole = true;
}

int32 UUnrealCSharpGeneratorCommandlet::Main(const FString& Params)
{
	// Commandlet 环境下资产注册表不会自动完成扫描，
	// 这里同步扫描一次，确保 FAssetGenerator::GetAssetsByPaths 能拿到完整资产列表
	auto& AssetRegistryModule = FModuleManager::LoadModuleChecked<FAssetRegistryModule>(TEXT("AssetRegistry"));

	AssetRegistryModule.Get().SearchAllAssets(true);

	FUnrealCSharpEditorModule::Generator();

	return 0;
}
