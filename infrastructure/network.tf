resource "google_compute_network" "vpc_network" {
  auto_create_subnetworks         = true
  delete_default_routes_on_create = false
  project_id                      = var.project_id
  network_name                    = var.network_name
  routing_mode                    = "GLOBAL"
}

resource "google_compute_network" "redis-network" {
  project_id                      = var.project_id
  delete_default_routes_on_create = false
  network_name                    = "redis-network"
  auto_create_subnetworks         = true
  routing_mode                    = "GLOBAL"
  mtu                             = 1460
}