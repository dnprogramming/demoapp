data "google_compute_network" "redis-network" {
  name = "redis-network"
}

resource "google_compute_global_address" "service_range" {
  name          = "address"
  purpose       = "VPC_PEERING"
  address_type  = "INTERNAL"
  prefix_length = 16
  network       = data.google_compute_network.redis-network.id
}

resource "google_service_networking_connection" "private_service_connection" {
  network                 = data.google_compute_network.redis-network.id
  service                 = "servicenetworking.googleapis.com"
  reserved_peering_ranges = [google_compute_global_address.service_range.name]
}

resource "google_redis_instance" "cache" {
  name           = "private-cache"
  tier           = "STANDARD_HA"
  memory_size_gb = 5

  location_id             = var.region_primary
  alternative_location_id = var.region_secondary

  authorized_network = data.google_compute_network.redis-network.id
  connect_mode       = "PRIVATE_SERVICE_ACCESS"

  redis_version = "REDIS_6_X"
  display_name  = "Redis storage"

  depends_on = [google_service_networking_connection.private_service_connection]

}