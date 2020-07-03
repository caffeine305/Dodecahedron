extends MeshInstance

var poly = preload("res://Assets/Poly.tscn")

func _process(delta):
	if Input.is_action_pressed("create"):
		Create()

func RandomPos():
	var x = rand_range(-10,10)
	var y = rand_range(10,20)
	var z = rand_range(-10,10)
	
	return Vector3(x,y,z)

func Create():
		#Shoot Example
	#	var bullet = BULLET.instance()
	#	get_node("/root/").add_child(bullet)
	#	bullet.set_translation(BulletPosition.get_global_transform().origin)
	#	bullet.direction = BulletPosition.get_global_transform().basis.z

	var poly_instance = poly.instance()
	get_node("/root/").add_child(poly_instance)
	#poly_instance.set_translation(self.get_global_transform().origin)
	poly_instance.set_translation(RandomPos())
	print("Created")
	print(RandomPos())
