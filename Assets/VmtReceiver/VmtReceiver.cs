/*
 * VmtReceiver
 * https://twitter.com/KenjiASABA
 *
 * MIT License
 * 
 * Copyright (c) 2021 K. Asaba
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using UnityEngine;
using UnityEngine.Events;

public class VmtReceiver : MonoBehaviour
{
    public uOSC.uOscServer server = null;

    // On data updated, these objects are moved. Delete them if you implement your own event.
    public GameObject[] gameObjectsToBeTransformed;

    public class DataUpdateEvent : UnityEvent<int, Vector3, Quaternion> { };

    public DataUpdateEvent OnDataUpdated { get; private set; }

    void Awake()
    {
        OnDataUpdated = new DataUpdateEvent();
    }

    void Start()
    {
        // Start listening
        server = GetComponent<uOSC.uOscServer>();
        if (server)
        {
            server.onDataReceived.AddListener(OnMessageReceived);
        }

        // Bind an event to OnDataUpdated
        this.OnDataUpdated.AddListener(SetTransforms);
    }

    private void OnMessageReceived(uOSC.Message message)
    {
        if (message.address == null || message.values == null)
        {
            return;
        }

        if (message.address == "/VMT/Room/Unity"
            && (message.values[0] is int) // tracker index
            && (message.values[1] is int) // enable
            && (message.values[2] is float) // time offset
            && (message.values[3] is float) // position.x
            && (message.values[4] is float) // position.y
            && (message.values[5] is float) // position.z
            && (message.values[6] is float) // rotation.x
            && (message.values[7] is float) // rotation.y
            && (message.values[8] is float) // rotation.z
            && (message.values[9] is float) // rotation.w
            )
        {
            int trackerIndex;
            Vector3 pos;
            Quaternion rot;

            trackerIndex = (int)message.values[0];
            pos.x = (float)message.values[3];
            pos.y = (float)message.values[4];
            pos.z = (float)message.values[5];
            rot.x = (float)message.values[6];
            rot.y = (float)message.values[7];
            rot.z = (float)message.values[8];
            rot.w = (float)message.values[9];

            OnDataUpdated.Invoke(trackerIndex, pos, rot);
        }
    }

    // To implement your own method, modify this, or implement a new method and bind it to OnDataUpdated
    private void SetTransforms(int trackerIndex, Vector3 pos, Quaternion rot)
    {
        if (trackerIndex >= 0 && gameObjectsToBeTransformed.Length > trackerIndex)
        {
            if (gameObjectsToBeTransformed[trackerIndex] != null)
            {
                gameObjectsToBeTransformed[trackerIndex].transform.position = pos;
                gameObjectsToBeTransformed[trackerIndex].transform.rotation = rot;
            }
        }
    }
}