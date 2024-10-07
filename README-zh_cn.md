[English（英文）](./README.md)   [简体中文(Simplified Chinese)](./README-zh_cn.md)


以下是原作者 `README.md` 的中文版本。本项目仅做翻译，不做修改

# Studio

# 注意：项目已暂时暂停。

查看原[AssetStudio项目](https://github.com/Perfare/AssetStudio)获取更多信息。

注意：需要互联网连接来获取 asset_index jsons。

_____________________________________________________________________________________________________________________________
如何使用：

查看教程[这里](https://gist.github.com/Modder4869/0f5371f8879607eb95b8e63badca227e)（感谢Modder4869编写教程）

_____________________________________________________________________________________________________________________________
CLI 版本：
```
描述：

用法：
  AssetStudioCLI <输入路径> <输出路径> [选项]

参数：
  <输入路径>   输入文件/文件夹。
  <输出路径>  输出文件夹。

选项：
  --silent                                                隐藏日志消息。
  --type <Texture2D|Sprite|等等>                         指定 unity 类类型
  --filter <过滤器>                                       指定正则表达式过滤器。
  --game <BH3|CB1|CB2|CB3|GI|SR|TOT|ZZZ> （必需）       指定游戏。
  --map_op <AssetMap|Both|CABMap|None>                    指定要构建的地图。 [默认：None]
  --map_type <JSON|XML>                                   AssetMap 输出类型。[默认：XML]
  --map_name <map_name>                                   指定 AssetMap 文件名。
  --group_assets_type <ByContainer|BySource|ByType|None>  指定如何将导出的资源分组。 [默认：0]
  --no_asset_bundle                                       从 AssetMap/Export 中排除 AssetBundle。
  --no_index_object                                       从 AssetMap/Export 中排除 IndexObject/MiHoYoBinData。
  --xor_key <xor_key>                                     XOR 密钥来解密 MiHoYoBinData。
  --ai_file <ai_file>                                     指定 asset_index json 文件路径（用于恢复 GI 容器）。
  --version                                               显示版本信息
  -?, -h, --help                                          显示帮助和用法信息
```
_____________________________________________________________________________________________________________________________
注意事项：
```
- 如果遇到“MeshRenderer/SkinnedMeshRenderer”错误，确保在加载资源前在“导出选项”中启用“禁用渲染器”选项。
- 在需要导出模型/动画师而不需要检索所有动画的情况下，确保在“选项 -> 导出选项”中启用“忽略控制器动画”选项。

```
特别感谢：
- Perfare：原始作者。
- Khang06：[项目](https://github.com/khang06/genshinblkstuff)用于提取。
- Radioegor146：[资产索引](https://github.com/radioegor146/gi-asset-indexes)用于恢复/更新 asset_index 的。
- Ds5678：[AssetRipper](https://github.com/AssetRipper/AssetRipper)[[discord](https://discord.gg/XqXa53W2Yh)]提供了有关资产格式和解析的信息。
- mafaca：[uTinyRipper](https://github.com/mafaca/UtinyRipper)用于 `YAML` 和 `AnimationClipConverter`。

