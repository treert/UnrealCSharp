#pragma once

#include "CoreMinimal.h"
#include "Commandlets/Commandlet.h"
#include "UnrealCSharpGeneratorCommandlet.generated.h"

// 在不启动 UE Editor 的情况下生成 UnrealCSharp 的 C# 代码
// 用法: UnrealEditor-Cmd.exe <Project>.uproject -run=UnrealCSharpGenerator
UCLASS(MinimalAPI)
class UUnrealCSharpGeneratorCommandlet final : public UCommandlet
{
	GENERATED_BODY()

public:
	UUnrealCSharpGeneratorCommandlet();

	virtual int32 Main(const FString& Params) override;
};
