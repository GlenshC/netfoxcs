class_name CustomNetworkSchema extends Object

static func vec2i(component_serializer: NetworkSchemaSerializer) -> NetworkSchemaSerializer:
	return _GenericVec2iSchema.new(component_serializer)

static func vec3i(component_serializer: NetworkSchemaSerializer) -> NetworkSchemaSerializer:
	return _GenericVec3iSchema.new(component_serializer)
	
static func vec4i(component_serializer: NetworkSchemaSerializer) -> NetworkSchemaSerializer:
	return _GenericVec4iSchema.new(component_serializer)


class _GenericVec2iSchema extends NetworkSchemaSerializer:
	var component: NetworkSchemaSerializer

	func _init(p_component: NetworkSchemaSerializer):
		component = p_component

	func encode(v: Variant, b: StreamPeerBuffer) -> void:
		component.encode(v.x, b)
		component.encode(v.y, b)

	func decode(b: StreamPeerBuffer) -> Variant:
		return Vector2i(
			component.decode(b), component.decode(b)
		)
		
class _GenericVec3iSchema extends NetworkSchemaSerializer:
	var component: NetworkSchemaSerializer

	func _init(p_component: NetworkSchemaSerializer):
		component = p_component

	func encode(v: Variant, b: StreamPeerBuffer) -> void:
		component.encode(v.x, b)
		component.encode(v.y, b)
		component.encode(v.z, b)

	func decode(b: StreamPeerBuffer) -> Variant:
		return Vector3i(
			component.decode(b), component.decode(b), component.decode(b)
		)
		
class _GenericVec4iSchema extends NetworkSchemaSerializer:
	var component: NetworkSchemaSerializer

	func _init(p_component: NetworkSchemaSerializer):
		component = p_component

	func encode(v: Variant, b: StreamPeerBuffer) -> void:
		component.encode(v.x, b)
		component.encode(v.y, b)
		component.encode(v.z, b)
		component.encode(v.w, b)

	func decode(b: StreamPeerBuffer) -> Variant:
		return Vector4i(
			component.decode(b), component.decode(b), component.decode(b), component.decode(b)
		)
