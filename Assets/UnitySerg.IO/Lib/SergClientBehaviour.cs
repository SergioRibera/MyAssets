using Serg.IO.Data;
using Serg.IO.Helper;
using UnityEngine;

namespace Serg.IO.Unity {
    public class SergClientBehaviour : MonoBehaviour {
        public SergClientSettings settings = new SergClientSettings();

        internal SergClient client;
        public void Start()
        {
            client = new SergClient(settings);
            Application.quitting += Disconnect;
        }
        /// <summary>
        /// Connects to local server.
        /// </summary>
        public void ConnectToLocalServer() => client.ConnectToLocalServer();
        public void ConnectToOnlineServer() => client.ConnectToOnlineServer();
        public void ChangeConnectionServer(bool isLocal) => client.ChangeConnectionServer(isLocal);
        /// <summary>
        /// Emit the specified event.
        /// </summary>
        /// <param name="name">Name of event</param>
        public void Emit(string name) => client.Emit(name);
        /// <summary>
        /// Emit the specified name and data.
        /// </summary>
        /// <param name="name">Nombre del evento</param>
        /// <param name="data">Contenido de datos</param>
        public void Emit(string name, string data) => client.Emit(name, data);
        /// <summary>
        /// Emit the specified name and data.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="data">Data.</param>
        public void Emit(string name, object data) => client.Emit(name, data);
        /// <summary>
        /// On the specified name and callback.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="callback">Callback.</param>
        public void On(string name, SergIOCallback callback) => client.On(name, callback);
        /// <summary>
        /// Disconnect this instance.
        /// </summary>
        public void Disconnect() => client.Disconnect();
    }
}