//server ads by said elmamouni
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.SceneManagement;
using System.Net;

public class DataLoader : MonoBehaviour
{
	string JsonDataString;
	public string OriginalJsonSite;
	//iron text
	public Text version;
	public string SceneToLoad;
	bool checkInternet = true;
	public GameObject Errorwindow;
	//public Text admoobid;
	//public Text admobinter;
	//public Text admobanner;
	//public Text admobreward; 
	//public Text FcbInter;
	//public Text Fcbbanner;
	//public Text Fcbreward;
	//public Text UnityAppIdtxt;
	//public Text UnityIntertxt;
	//public Text unityBannertxt;
	//public Text unityrewardtxt;
	void Awake()
	{
		//ntestiw ads khawiyn nchofo ach radi i3tina
		//PlayerPrefs.DeleteAll();
		//lanciw fonction bach nchekiw internet

		string HtmlText = GetHtmlFromUri("http://google.com");
		if (HtmlText == "")
		{
			//No connection
			print("no internet ");
			checkInternet = false;
			///	kharaj lih fenetre fiha error connection ola load scene game
			if (Errorwindow != null)
			{
				Errorwindow.SetActive(true);

			}
		}
		else
		{
			///lancer scene li bghiti 
			StartCoroutine(load());
		}
		Invoke("LaunchGame", 7);
	}


	IEnumerator load()
	{


		WWW readingsite = new WWW(OriginalJsonSite);
		yield return readingsite;
		print(readingsite);

		if (string.IsNullOrEmpty(readingsite.url))
		{
			print(" ads empty");
			if (SceneToLoad != null)
			{
				SceneManager.LoadScene(SceneToLoad);

			}
			checkInternet = false;

		}
		if (checkInternet)


		{

			JsonDataString = readingsite.text;
			JSONNode jsonNode = SimpleJSON.JSON.Parse(JsonDataString);
			//frequence and adsorder stuff
			string frequence = jsonNode["Frequence"];
			string adsorderInter = jsonNode["specificationAdsInter"];
			string adsorderReward = jsonNode["specificationAdsReward"];
			string adsorderbanner = jsonNode["specificationAdsbanner"];

			PlayerPrefs.SetInt("Frequence", int.Parse(frequence));

			//PlayerPrefs.SetInt("specificationAdsInter", int.Parse(adsorderInter));
			//PlayerPrefs.SetInt("specificationAdsReward", int.Parse(adsorderReward));
			//PlayerPrefs.SetInt("specificationAdsbanner", int.Parse(adsorderbanner));


			//version stuff
			string versionkey = jsonNode["version"];
			PlayerPrefs.SetString("version", versionkey);
			//key1 iron stuff
			string ironKey = jsonNode["ironKey"];
			string ironinter = jsonNode["ironinter"];
			string ironbanner = jsonNode["ironbanner"];
			string ironReward = jsonNode["ironReward"];






			//showing text
			if (version != null)
			{
				version.text = versionkey;

			}

			//saving key
			PlayerPrefs.SetString("ironKey", ironKey);
			PlayerPrefs.SetString("ironinter", ironinter);
			PlayerPrefs.SetString("ironbanner", ironbanner);
			PlayerPrefs.SetString("ironReward", ironReward);

			//////////////////////////////////////////////

			/// //key 2 admob stuff
			string AdmobAppID = jsonNode["AdmobAppId"];
			string AdmobInter = jsonNode["interId"];
			string AdmobBanner = jsonNode["bannerId"];
			string AdmobReward = jsonNode["rewardadmob"];
			string Nativeadmob = jsonNode["Nativeadmob"];
			string Onesignalkey = jsonNode["Onesignalkey"];
			string AdmobAppIdNative1 = jsonNode["AdmobAppIdNative1"];

			//remove quotes
			//AdmobAppID = AdmobAppID.Trim("\"".ToCharArray());
			//AdmobInter = AdmobInter.Trim("\"".ToCharArray());
			//AdmobBanner = AdmobBanner.Trim("\"".ToCharArray());
			//AdmobReward = AdmobReward.Trim("\"".ToCharArray());
			//showing text
			//admoobid.text = AdmobAppID;
			//admobinter.text = AdmobInter;
			//admobanner.text = AdmobBanner;
			//admobreward.text = AdmobReward;

			//saving key
			PlayerPrefs.SetString("AdmobAppId", AdmobAppID);
			PlayerPrefs.SetString("admobinter", AdmobInter);
			PlayerPrefs.SetString("bannerId", AdmobBanner);
			PlayerPrefs.SetString("admobreward", AdmobReward);
			PlayerPrefs.SetString("Nativeadmob", Nativeadmob);
			PlayerPrefs.SetString("AdmobAppIdNative1", AdmobAppIdNative1);

			PlayerPrefs.SetString("Onesignalkey", Onesignalkey);

			//////////////////////////////////////////////////////

			//key 3 facebook stuff

			string FANinter = jsonNode["FanInter"];
			string FANbanner = jsonNode["FanBanner"];
			string FANreward = jsonNode["FanReward"];
			//remove quotes
			//FANinter = FANinter.Trim("\"".ToCharArray());
			//FANbanner = FANbanner.Trim("\"".ToCharArray());
			//FANreward = FANreward.Trim("\"".ToCharArray());
			//showing text
			//FcbInter.text = FANinter;
			//	Fcbbanner.text = FANbanner;
			//Fcbreward.text = FANreward;
			//saving key
			PlayerPrefs.SetString("FcbInter", FANinter);
			PlayerPrefs.SetString("Fcbbanner", FANbanner);
			PlayerPrefs.SetString("Fcbreward", FANreward);


			////////////////////////////////////////////////
			//key 3 unity stuff

			string UnityApp = jsonNode["UnityAppId"];
			string UnityInt = jsonNode["UnityInter"];
			string Unityban = jsonNode["Unitybanner"];
			string unityrew = jsonNode["unityreward"];

			//remove quotes
			//UnityApp = UnityApp.Trim("\"".ToCharArray());
			//UnityInt = UnityInt.Trim("\"".ToCharArray());
			//Unityban = Unityban.Trim("\"".ToCharArray());
			//unityrew = unityrew.Trim("\"".ToCharArray());

			//showing text
			//	UnityAppIdtxt.text = UnityApp;
			//UnityIntertxt.text = UnityInt;
			//	unityBannertxt.text = Unityban;
			//unityrewardtxt.text = unityrew;

			//saving key
			PlayerPrefs.SetString("UnityAppId", UnityApp);
			PlayerPrefs.SetString("UnityInter", UnityInt);
			PlayerPrefs.SetString("Unitybanner", Unityban);
			PlayerPrefs.SetString("unityreward", unityrew);
			yield return new WaitForSeconds(5);
			//SceneManager.LoadScene("MENU");

			PlayerPrefs.Save();
			StartCoroutine(loadingScene());
		}

	}




	IEnumerator loadingScene()
	{
		//loader scene li bghiti men be3d matcharjaw ads
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene(SceneToLoad);
	}

	//nzido function ilq kan ads khawi ola no internet 

	public string GetHtmlFromUri(string resource)
	{
		string html = string.Empty;
		HttpWebRequest req = (HttpWebRequest)WebRequest.Create(resource);
		try
		{
			using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
			{
				bool isSuccess = (int)resp.StatusCode < 299 && (int)resp.StatusCode >= 200;
				if (isSuccess)
				{
					using (System.IO.StreamReader reader = new System.IO.StreamReader(resp.GetResponseStream()))
					{
						//We are limiting the array to 80 so we don't have
						//to parse the entire html document feel free to 
						//adjust (probably stay under 300)
						char[] cs = new char[80];
						reader.Read(cs, 0, cs.Length);
						foreach (char ch in cs)
						{
							html += ch;
						}
					}
				}
			}
		}
		catch
		{
			return "";
		}
		return html;
	}

	public void LaunchGame()
	{

		SceneManager.LoadScene(SceneToLoad);

	}
	public void QuitGame()
	{
		Application.Quit();
		print("Quit Game");
	}
}