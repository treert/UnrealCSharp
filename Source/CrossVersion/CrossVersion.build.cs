// Copyright Epic Games, Inc. All Rights Reserved.

using System.IO;
using UnrealBuildTool;

public class CrossVersion : ModuleRules
{
	public CrossVersion(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		
		PublicIncludePaths.AddRange(
			new string[] {
				// ... add public include paths required here ...
			}
			);
				
		
		PrivateIncludePaths.AddRange(
			new string[] {
				// ... add other private include paths required here ...
			}
			);
			
		
		PublicDependencyModuleNames.AddRange(
			new string[]
			{
				"Core",
				// ... add other public dependencies that you statically link with here ...
			}
			);

		// 检测 HAZE 引擎分支（AngelScript 集成）：该分支引擎自带 Plugins/Angelscript 插件，
		// 且 CoreUObject 的 Class.h (HAZE-FIX) 中新增了 TBaseStructure<FBox>/<FBoxSphereBounds> 等特化。
		// 通过 PublicDefinitions 注入宏，传播到所有依赖 CrossVersion 的模块。
		// 注：EngineDirectory 是 ModuleRules 的静态属性，不是 Target 上的属性。
		var AngelscriptPluginPath = Path.Combine(EngineDirectory, "Plugins", "Angelscript");
		PublicDefinitions.Add(Directory.Exists(AngelscriptPluginPath)
			? "UNREALCSHARP_HAZE_ANGELSCRIPT=1"
			: "UNREALCSHARP_HAZE_ANGELSCRIPT=0");
			
		
		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				"CoreUObject",
				"Engine",
				"Slate",
				"SlateCore",
				// ... add private dependencies that you statically link with here ...	
			}
			);
		
		
		DynamicallyLoadedModuleNames.AddRange(
			new string[]
			{
				// ... add any modules that your module loads dynamically here ...
			}
			);
	}
}
