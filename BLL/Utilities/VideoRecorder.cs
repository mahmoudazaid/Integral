using BLL.Browser;
using Microsoft.Expression.Encoder.ScreenCapture;
using OpenQA.Selenium;
using System;
using System.IO;

namespace BLL.Utilities
{
    public class VideoRecorder
    {
        private static readonly ScreenCaptureJob vidRec = new ScreenCaptureJob();

        public static void StartRecordingVideo(string scenarioTitle)
        {            
            string VideoPath = Path.Combine(Directory.GetCurrentDirectory() + "\\ViedoRecords\\");
            FilesManager.CreateFolder(VideoPath);


            string timestamp = DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss");
            vidRec.OutputScreenCaptureFileName = VideoPath  + scenarioTitle + " " + timestamp + ".mp4";            
            vidRec.Start();
        }

        public static void EndRecording()
        {
            vidRec.Stop();
        }
    }


}
