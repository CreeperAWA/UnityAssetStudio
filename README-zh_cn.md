[English��Ӣ�ģ�](./README.md)   [��������(Simplified Chinese)](./README-zh_cn.md)


������ԭ���� `README.md` �����İ汾������Ŀ�������룬�����޸�

# Studio

# ע�⣺��Ŀ����ʱ��ͣ��

�鿴ԭ[AssetStudio��Ŀ](https://github.com/Perfare/AssetStudio)��ȡ������Ϣ��

ע�⣺��Ҫ��������������ȡ asset_index jsons��

_____________________________________________________________________________________________________________________________
���ʹ�ã�

�鿴�̳�[����](https://gist.github.com/Modder4869/0f5371f8879607eb95b8e63badca227e)����лModder4869��д�̳̣�

_____________________________________________________________________________________________________________________________
CLI �汾��
```
������

�÷���
  AssetStudioCLI <����·��> <���·��> [ѡ��]

������
  <����·��>   �����ļ�/�ļ��С�
  <���·��>  ����ļ��С�

ѡ�
  --silent                                                ������־��Ϣ��
  --type <Texture2D|Sprite|�ȵ�>                         ָ�� unity ������
  --filter <������>                                       ָ��������ʽ��������
  --game <BH3|CB1|CB2|CB3|GI|SR|TOT|ZZZ> �����裩       ָ����Ϸ��
  --map_op <AssetMap|Both|CABMap|None>                    ָ��Ҫ�����ĵ�ͼ�� [Ĭ�ϣ�None]
  --map_type <JSON|XML>                                   AssetMap ������͡�[Ĭ�ϣ�XML]
  --map_name <map_name>                                   ָ�� AssetMap �ļ�����
  --group_assets_type <ByContainer|BySource|ByType|None>  ָ����ν���������Դ���顣 [Ĭ�ϣ�0]
  --no_asset_bundle                                       �� AssetMap/Export ���ų� AssetBundle��
  --no_index_object                                       �� AssetMap/Export ���ų� IndexObject/MiHoYoBinData��
  --xor_key <xor_key>                                     XOR ��Կ������ MiHoYoBinData��
  --ai_file <ai_file>                                     ָ�� asset_index json �ļ�·�������ڻָ� GI ��������
  --version                                               ��ʾ�汾��Ϣ
  -?, -h, --help                                          ��ʾ�������÷���Ϣ
```
_____________________________________________________________________________________________________________________________
ע�����
```
- ���������MeshRenderer/SkinnedMeshRenderer������ȷ���ڼ�����Դǰ�ڡ�����ѡ������á�������Ⱦ����ѡ�
- ����Ҫ����ģ��/����ʦ������Ҫ�������ж���������£�ȷ���ڡ�ѡ�� -> ����ѡ������á����Կ�����������ѡ�

```
�ر��л��
- Perfare��ԭʼ���ߡ�
- Khang06��[��Ŀ](https://github.com/khang06/genshinblkstuff)������ȡ��
- Radioegor146��[�ʲ�����](https://github.com/radioegor146/gi-asset-indexes)���ڻָ�/���� asset_index �ġ�
- Ds5678��[AssetRipper](https://github.com/AssetRipper/AssetRipper)[[discord](https://discord.gg/XqXa53W2Yh)]�ṩ���й��ʲ���ʽ�ͽ�������Ϣ��
- mafaca��[uTinyRipper](https://github.com/mafaca/UtinyRipper)���� `YAML` �� `AnimationClipConverter`��

