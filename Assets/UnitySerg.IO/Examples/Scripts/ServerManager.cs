using UnityEngine;
using UnityEngine.UI;
using Serg.IO.Unity;
public class ServerManager : SergServerBehaviour
{
    public Transform msgContent;
    public GameObject showMsg;
    public Text txtStatus;
    public Button startServer;
    public InputField myMsg;
    public Button sendMsg;

    new void Start()
    {
        base.Start();
        PrepareButtonsListener();
        PrepareServerEvents();
    }

    void PrepareButtonsListener()
    {
        // Preparamos el evento para que al hacer click este inicie el servidor
        startServer.onClick.AddListener(() => StartServer());
        // Preparamos el evento para que al hacer click este envie el mensaje escrito en el input
        sendMsg.onClick.AddListener(SendMsg);
    }

    void PrepareServerEvents()
    {
        On("message", data => {
            InstantiateMsgObject(data, false);
            Debug.Log(data);
        });
        On("server-start", data =>
        {
            txtStatus.text = $"Servidor iniciado en {data}:{settings.port}";
            txtStatus.color = Color.black;
        });
    }
    public void SendMsg(){
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