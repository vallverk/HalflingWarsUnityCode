using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AchivementsDetails : MonoBehaviour 
{
	private List<GameCenterAchievementMetadata> _achievementMetadata;
	private List<GameCenterLeaderboard> _leaderboards;
	
	public int 	percentComplete1,percentComplete2,percentComplete3,percentComplete4,percentComplete5,percentComplete6,percentComplete7,
				percentComplete8,percentComplete9,percentComplete10,percentComplete11,percentComplete12,percentComplete13,percentComplete14,
				percentComplete15,percentComplete16,percentComplete17,percentComplete18,percentComplete19,percentComplete20,percentComplete21,
				percentComplete22,percentComplete23,percentComplete24,percentComplete25,percentComplete26,percentComplete27,percentComplete28,
				percentComplete29,percentComplete30,percentComplete31,percentComplete32,percentComplete33,percentComplete34,percentComplete35,
				percentComplete36,percentComplete37,percentComplete38,percentComplete39,percentComplete40,percentComplete41,percentComplete42,
				percentComplete43,percentComplete44,percentComplete45,percentComplete46,percentComplete47,percentComplete48;
	
	public int plantHarvestCount;
	public int DecorationCount;
	public int potionCount;
	public int traininggroundCreatureCount;
	
	public int GoldProducingBuildingsCount;
	public int tavernCount;
	public int obelisksCount;
	public int ShrinesCount;
	public int halflingCreaturesCount;
	public int darklingCreaturesCount;
	public int CreatureCount;
	public int enemyCaveCount;
	public int friendcount;
	public int wonfightcount;
	public int totalfightcount;
	public AudioController  scr_audioController;
	
	// Use this for initialization
	void Start () 
	{
		GameCenterManager.categoriesLoaded += delegate( List<GameCenterLeaderboard> leaderboards )
		{
			_leaderboards = leaderboards;
		};
		GameCenterManager.achievementMetadataLoaded += delegate( List<GameCenterAchievementMetadata> achievementMetadata )
		{
			_achievementMetadata = achievementMetadata;
		};
		
		GameCenterBinding.authenticateLocalPlayer();
		
		scr_audioController = GameObject.Find("Audio").GetComponent<AudioController>();
		
		//PlayerPrefs.GetInt("plantharvestcount");
	}
	
	
	private void PlayAchievementSounds()
	{
		scr_audioController.audio_achievement.Play();
		scr_audioController.audio_achievement.minDistance = 1;
		scr_audioController.audio_achievement.maxDistance = 300;
		scr_audioController.audio_achievement.volume = 0.8f;
		scr_audioController.audio_achievement.loop = false;
	}
	
	
	public void gameCenterAchivementList()
	{
		PlayAchievementSounds();
		
		GameCenterBinding.retrieveAchievementMetadata();
		GameCenterBinding.loadLeaderboardTitles();
	
		if( _achievementMetadata != null && _achievementMetadata.Count > 0 )
		{
			GameCenterBinding.reportAchievement( _achievementMetadata[0].identifier, percentComplete1 );	GameCenterBinding.reportAchievement( _achievementMetadata[1].identifier, percentComplete2 );
			GameCenterBinding.reportAchievement( _achievementMetadata[2].identifier, percentComplete3 );	GameCenterBinding.reportAchievement( _achievementMetadata[3].identifier, percentComplete4 );
			GameCenterBinding.reportAchievement( _achievementMetadata[4].identifier, percentComplete5 );	GameCenterBinding.reportAchievement( _achievementMetadata[5].identifier, percentComplete6 );
			GameCenterBinding.reportAchievement( _achievementMetadata[6].identifier, percentComplete7 );	GameCenterBinding.reportAchievement( _achievementMetadata[7].identifier, percentComplete8 );
			GameCenterBinding.reportAchievement( _achievementMetadata[8].identifier, percentComplete9 );	GameCenterBinding.reportAchievement( _achievementMetadata[9].identifier, percentComplete10);
				
				
			GameCenterBinding.reportAchievement( _achievementMetadata[10].identifier,percentComplete11);	GameCenterBinding.reportAchievement( _achievementMetadata[11].identifier,percentComplete12);
			GameCenterBinding.reportAchievement( _achievementMetadata[12].identifier,percentComplete13);	GameCenterBinding.reportAchievement( _achievementMetadata[13].identifier,percentComplete14);
			GameCenterBinding.reportAchievement( _achievementMetadata[14].identifier,percentComplete15);	GameCenterBinding.reportAchievement( _achievementMetadata[15].identifier,percentComplete16);
			GameCenterBinding.reportAchievement( _achievementMetadata[16].identifier,percentComplete17);	GameCenterBinding.reportAchievement( _achievementMetadata[17].identifier,percentComplete18);
			GameCenterBinding.reportAchievement( _achievementMetadata[18].identifier,percentComplete19);	GameCenterBinding.reportAchievement( _achievementMetadata[19].identifier,percentComplete20);
				
				
			GameCenterBinding.reportAchievement( _achievementMetadata[20].identifier,percentComplete21);	GameCenterBinding.reportAchievement( _achievementMetadata[21].identifier,percentComplete22);
			GameCenterBinding.reportAchievement( _achievementMetadata[22].identifier,percentComplete23);	GameCenterBinding.reportAchievement( _achievementMetadata[23].identifier,percentComplete24);
			GameCenterBinding.reportAchievement( _achievementMetadata[24].identifier,percentComplete25);	GameCenterBinding.reportAchievement( _achievementMetadata[25].identifier,percentComplete26);
			GameCenterBinding.reportAchievement( _achievementMetadata[26].identifier,percentComplete27);	GameCenterBinding.reportAchievement( _achievementMetadata[27].identifier,percentComplete28);
			GameCenterBinding.reportAchievement( _achievementMetadata[28].identifier,percentComplete29);	GameCenterBinding.reportAchievement( _achievementMetadata[29].identifier,percentComplete30);
				
				
			GameCenterBinding.reportAchievement( _achievementMetadata[30].identifier,percentComplete31);	GameCenterBinding.reportAchievement( _achievementMetadata[31].identifier,percentComplete32);
			GameCenterBinding.reportAchievement( _achievementMetadata[32].identifier,percentComplete33);	GameCenterBinding.reportAchievement( _achievementMetadata[33].identifier,percentComplete34);
			GameCenterBinding.reportAchievement( _achievementMetadata[34].identifier,percentComplete35);	GameCenterBinding.reportAchievement( _achievementMetadata[35].identifier,percentComplete36);
			GameCenterBinding.reportAchievement( _achievementMetadata[36].identifier,percentComplete37);	GameCenterBinding.reportAchievement( _achievementMetadata[37].identifier,percentComplete38);
			GameCenterBinding.reportAchievement( _achievementMetadata[38].identifier,percentComplete39);	GameCenterBinding.reportAchievement( _achievementMetadata[39].identifier,percentComplete40);
				
				
			GameCenterBinding.reportAchievement( _achievementMetadata[40].identifier,percentComplete41);	GameCenterBinding.reportAchievement( _achievementMetadata[41].identifier,percentComplete42);
			GameCenterBinding.reportAchievement( _achievementMetadata[42].identifier,percentComplete43);	GameCenterBinding.reportAchievement( _achievementMetadata[43].identifier,percentComplete44);
			GameCenterBinding.reportAchievement( _achievementMetadata[44].identifier,percentComplete45);	GameCenterBinding.reportAchievement( _achievementMetadata[45].identifier,percentComplete46);
			GameCenterBinding.reportAchievement( _achievementMetadata[46].identifier,percentComplete47);	GameCenterBinding.reportAchievement( _achievementMetadata[47].identifier,percentComplete48);
		}
		else
		{
			Debug.Log( "you must load achievement metadata before you can post an achievement" );
		}
			
		if( _leaderboards != null && _leaderboards.Count > 0 )
		{
			Debug.Log( "about to report a random score for leaderboard: " + _leaderboards[0].leaderboardId );
			GameCenterBinding.reportScore(GameManager.TotalLevelxp , _leaderboards[0].leaderboardId );
		}
			
		GameCenterBinding.showLeaderboardWithTimeScope( GameCenterLeaderboardTimeScope.AllTime );
	}
	
	// Update is called once per frame
	void OnGUI() 
	{
		//if (GUI.Button(new Rect(100, 250, 100, 20),"GC Clear"))
		//{
		//	GameCenterBinding.resetAchievements();
		//}
	}
}
