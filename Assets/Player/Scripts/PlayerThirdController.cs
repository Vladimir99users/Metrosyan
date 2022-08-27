using UnityEngine;

sealed class PlayerThirdController : MonoBehaviour
{
    private Player _player => GetComponent<Player>() as Player;

   // [SerializeField] private Magic _magic;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _point;

    [Tooltip("Время для нового выстрела")]
    [SerializeField] private float _reloadedFire; // 5;
    private float _timeToFire;

    private void Start()
    {
        _timeToFire = _reloadedFire;
    }
    private void Update()
    {
        OnMouseDragPosition();
        if(Input.GetAxis("Fire1") == 1)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance); // переменной записываються координаты мыши по иксу и игрику
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); 
          //  _player.CreatMagic(objPosition);
        } else _timeToFire += Time.deltaTime;
    }


    private Vector3 DirectionVectorСalculation()
    {
        Vector3 position = _camera.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(position);
        return position;
    }


    public float distance = 10f;
 
    private void OnMouseDragPosition()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance); // переменной записываються координаты мыши по иксу и игрику
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); // переменной - объекту присваиваеться переменная с координатами мыши
       
       
        _point.position = objPosition; // и собственно объекту записываються координаты
    }

}
