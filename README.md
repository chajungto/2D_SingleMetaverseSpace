# 2D_SingleMetaverseSpace
 내일배움캠프 과제

------------------------------------------------------------------------------
##프로젝트 소개
내일배움캠프 안의 ZEP공간을 멀티가 아닌 싱글로 일단 구현해보자. 
캐릭터를 생성해 메인화면으로 들어가서 NPC들과 상호작용하고 미니게임도 즐겨보자.

------------------------------------------------------------------------------
###개발 환경
- Unity 2022.3.17f1
- Visual Studio 연동

------------------------------------------------------------------------------
###사용한 에셋
- 맵 구성 
<https://assetstore.unity.com/packages/2d/environments/the-japan-collection-arcade-music-207905>
<https://assetstore.unity.com/packages/2d/environments/the-japan-collection-japanese-city-free-version-278915>

- NPC 
<https://assetstore.unity.com/packages/2d/characters/2d-character-cute-animal-party-300393>

- 플래피 버드
<https://assetstore.unity.com/packages/2d/environments/landscape-tiles-birds-free-93903>

------------------------------------------------------------------------------
####프로젝트 구성
- 총 4개의 씬으로 구성되어 있습니다.
- StartScene : 시작할때 바로 로드되는 씬. 이름을 입력하고 입장하면 됩니다.
- MainScene : 플레이어가 돌아다니게 될 맵이며 메인잉 되는 씬, 해당 씬에서 NPC와 대화하여 미니게임을 즐길 수 있습니다.
- FlappyBirdGameScene : 플래피버드 게임을 즐길 수 있는 씬입니다.
- FindErrorGameScene : "오류를 찾아라!" 게임을 할 수 있는 씬입니다.

------------------------------------------------------------------------------
#####버그 
- NPC와 대화시도 중 방향킬르 꾹 누르는 경우 계속 플레이어가 해당 방향으로 이동하는 문제 [현재 수정 완료]

