using DG.Tweening;
using Dropbox.Api;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class MovementScript : MonoBehaviour
{
    
    public Transform tr;
    public LineRenderer lr;
    private float _time;
    private List<Vector3> _trajectory;
    private bool _loop;
    private string _bodyJsonString;

    private IEnumerator Start()
    {
        string token = "sl.Att8NwrzTVNSFlRuBryu0s9qUBnr1kti34CPlURfnhtUaXbcGfp4FeEnFYtQyNPZhusqgKDvvIOf_NMVmFaZQ1xCaJKGUg1iE2wWCQ5rt_w0Em5vznFIRxCCFzUgotPZndoUnoU";
        Sequence mySequence = DOTween.Sequence();

        

        //Dictionary<string, string> postHeader = new Dictionary<string, string>();
        //postHeader.Add("Authorization", "Bearer " + token);
        //postHeader.Add("Dropbox-API-Arg", "{\"path\": \"/provaupload.json\"}");
        //postHeader.Add("Content-Type", "");
        //using (UnityWebRequest request = UnityWebRequest.Get("https://www.dropbox.com/sh/2bym9ochyew91e5/AAAeZgiDflL1z_De1-mEZ9qTa?dl=0/Data.json"))
        ////"https://content.dropboxapi.com/2/files/download", null, postHeader))
        //{
        //    //request.SetRequestHeader("Authorization", "Bearer " + token);
            
        //    yield return request.SendWebRequest();
        //    if (request.error != null)
        //    {
        //        Debug.Log(request.error + " " + request.error);
        //    }
        //    else
        //    {
        //        Debug.Log("Success! " + request.downloadHandler.text);
        //    }
        //}
        yield return null;



        //lr.positionCount = _trajectory.Count;

        //await Task.Run( GetDropBoxFile);
        //foreach (var t in _trajectory)
        //{
        //    mySequence.Append(transform.DOMove(t, _time / _trajectory.Count));
        //    lr.SetPosition(_trajectory.IndexOf(t), t);                      
        //}

        //DOTween.Play(mySequence);

    }


    //static async Task GetDropBoxFile()
    //{
    //    string token = "sl.Att8NwrzTVNSFlRuBryu0s9qUBnr1kti34CPlURfnhtUaXbcGfp4FeEnFYtQyNPZhusqgKDvvIOf_NMVmFaZQ1xCaJKGUg1iE2wWCQ5rt_w0Em5vznFIRxCCFzUgotPZndoUnoU";
    //    using (var dbx = new DropboxClient(token))
    //    {
    //        using (var response = await dbx.Files.DownloadAsync("Test" + "/" + "Data.json"))
    //        {
    //            Debug.Log(await response.GetContentAsStringAsync());
    //        }


    //    }
    //}
    



}


