﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciribob.DCS.SimpleRadio.Standalone.Client
{
    public class AppConfiguration
    {
        public enum RegKeys
        {
            AUDIO_INPUT_DEVICE_ID,
            AUDIO_OUTPUT_DEVICE_ID,
            LAST_SERVER,
            MIC_BOOST
        }

        const string REG_PATH = "HKEY_CURRENT_USER\\SOFTWARE\\DCS-SimpleRadioStandalone";

        private int _audioInputDeviceId;
        private int _audioOutputDeviceId;
        private String _lastServer;
        private float _micBoost;

        public AppConfiguration()
        {
            try
            {
                AudioInputDeviceId = (int)Registry.GetValue(REG_PATH,
                  RegKeys.AUDIO_INPUT_DEVICE_ID.ToString(),
                  0);
            }
            catch (Exception ex)
            {
                AudioInputDeviceId = 0;
            }

            try
            {
                AudioOutputDeviceId = (int)Registry.GetValue(REG_PATH,
                   RegKeys.AUDIO_OUTPUT_DEVICE_ID.ToString(),
                   0);
            }
            catch (Exception ex)
            {
                AudioOutputDeviceId = 0;
            }

            try
            {
                LastServer = (String)Registry.GetValue(REG_PATH,
                    RegKeys.LAST_SERVER.ToString(),
                   "127.0.0.1");

            }
            catch (Exception ex)
            {
                LastServer = "127.0.0.1";
            }

            try
            {
                MicBoost = float.Parse( (String)Registry.GetValue(REG_PATH,
                    RegKeys.MIC_BOOST.ToString(),
                    "1.0"));
            }
            catch (Exception ex)
            {
                MicBoost = 1.0f;
            }
           
           

            

        }


        public int AudioInputDeviceId
        {
            get
            {
                return _audioInputDeviceId;
            }
            set
            {
                _audioInputDeviceId = value;

                Registry.SetValue(REG_PATH,
            RegKeys.AUDIO_INPUT_DEVICE_ID.ToString(),
            _audioInputDeviceId);

            }
        }

        public int AudioOutputDeviceId
        {
            get
            {
                return _audioOutputDeviceId;
            }
            set
            {
                _audioOutputDeviceId = value;

                Registry.SetValue(REG_PATH,
                    RegKeys.AUDIO_OUTPUT_DEVICE_ID.ToString(),
                    _audioOutputDeviceId);

            }
        }
        public String LastServer
        {
            get
            {
                return _lastServer;
            }
            set
            {
                _lastServer = value;

                Registry.SetValue(REG_PATH,
                 RegKeys.LAST_SERVER.ToString(),
                _lastServer);

            }
        }
        public float MicBoost
        {
            get
            {
                return _micBoost;
            }
            set
            {
                _micBoost = value;

                Registry.SetValue(REG_PATH,
                 RegKeys.MIC_BOOST.ToString(),
                _micBoost);

            }
        }
    }
}