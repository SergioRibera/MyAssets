using UnityEngine;
using UnityEngine.UI;
using Serg.IO.Unity;

public class ClientManager : SergClientBehaviour {
    public Transform msgContent;
    public GameObject showMsg;
    public Text txtStatus;
    public Button connectClient;
    public InputField ipServer;
    public InputField myMsg;
    public Button sendMsg;

    void Start()
    {
        base.Start();
        PrepareButtonsListener();
        PrepareServerEvents();
    }

    void PrepareButtonsListener()
    {
        // Preparamos el evento para que al hacer click este inicie el servidor
        connectClient.onClick.AddListener(() => {
            if(string.IsNullOrEmpty(ipServer.text) || string.IsNullOrWhiteSpace(ipServer.text)){
                txtStatus.text = "Ninguna IP de servidor introducida";
                return;
            }
            settings.ipConnect = ipServer.text;
            txtStatus.text = $"Intentando conectar con {settings.ipConnect}:{settings.port}";
            ConnectToLocalServer();
        });
        // Preparamos el evento para que al hacer click este envie el mensaje escrito en el input
        sendMsg.onClick.AddListener(SendMsg);
    }

    void PrepareServerEvents()
    {
        On("message", data => {
            InstantiateMsgObject(data, false);
            Debug.Log(data);
        });
        On("server-connect", data => {
            txtStatus.text = $"Conectado con el servidor";
            txtStatus.color = Color.black;
        });
    }
    public void SendMsg()
    {
        Emit("message", myMsg.text);
        InstantiateMsgObject(myMsg.text, true);
        myMsg.text = "";
    }

    GameObject go;
    Text goText;
    void InstantiateMsgObject(string content, bool me)
    {
        go = Instantiate(showMsg, msgContent);
        goText = go.GetComponent<Text>();
        goText.text = content;
        goText.color = me ? Color.blue : Color.yellow;
        goText.alignment = me ? TextAnchor.MiddleRight : TextAnchor.MiddleLeft;
    }
}
