resource "google_container_cluster" "demo_cluster" {
  project  = var.project_id
  name     = "demo-cluster"
  location = var.region_primary

  min_master_version = "1.27"

  # Enable Alias IPs to allow Windows Server networking.
  ip_allocation_policy {
    cluster_ipv4_cidr_block  = "/14"
    services_ipv4_cidr_block = "/20"
  }

  # Removes the implicit default node pool, recommended when using
  # google_container_node_pool.
  remove_default_node_pool = true
  initial_node_count       = 3
}

resource "google_container_cluster" "demo_cluster_failover" {
  project  = var.project_id
  name     = "demo-cluster-failover"
  location = var.region_secondary

  min_master_version = "1.27"

  # Enable Alias IPs to allow Windows Server networking.
  ip_allocation_policy {
    cluster_ipv4_cidr_block  = "/14"
    services_ipv4_cidr_block = "/20"
  }

  # Removes the implicit default node pool, recommended when using
  # google_container_node_pool.
  remove_default_node_pool = true
  initial_node_count       = 3
}

# Small Linux node pool to run some Linux-only Kubernetes Pods.
resource "google_container_node_pool" "linux_pool" {
  name     = "linux-pool"
  project  = google_container_cluster.demo_cluster.project
  cluster  = google_container_cluster.demo_cluster.name
  location = google_container_cluster.demo_cluster.location

  node_config {
    image_type = "COS_CONTAINERD"
  }
}

# Small Linux node pool to run some Linux-only Kubernetes Pods.
resource "google_container_node_pool" "linux_pool_failover" {
  name     = "linux-pool-failover"
  project  = google_container_cluster.demo_cluster_failover.project
  cluster  = google_container_cluster.demo_cluster_failover.name
  location = google_container_cluster.demo_cluster_failover.location

  node_config {
    image_type = "COS_CONTAINERD"
  }
}