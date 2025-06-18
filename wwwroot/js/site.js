// DevTrack Site JavaScript
console.log('DevTrack site.js loaded');

// DevTrack Mobile Navigation
console.log('DevTrack site.js loaded');

// Mobile navigation functions
function toggleMobileNav() {
    console.log('Toggle mobile nav called');
    const sidebar = document.getElementById('mobileSidebar');
    const overlay = document.getElementById('mobileOverlay');
    
    if (sidebar && overlay) {
        const isOpen = sidebar.classList.contains('mobile-open');
        
        if (isOpen) {
            closeMobileNav();
        } else {
            openMobileNav();
        }
    } else {
        console.error('Mobile navigation elements not found');
    }
}

function openMobileNav() {
    console.log('Opening mobile nav');
    const sidebar = document.getElementById('mobileSidebar');
    const overlay = document.getElementById('mobileOverlay');
    
    if (sidebar) {
        sidebar.classList.add('mobile-open');
    }
    if (overlay) {
        overlay.classList.add('show');
    }
    
    // Prevent body scroll
    document.body.style.overflow = 'hidden';
}

function closeMobileNav() {
    console.log('Closing mobile nav');
    const sidebar = document.getElementById('mobileSidebar');
    const overlay = document.getElementById('mobileOverlay');
    
    if (sidebar) {
        sidebar.classList.remove('mobile-open');
    }
    if (overlay) {
        overlay.classList.remove('show');
    }
    
    // Restore body scroll
    document.body.style.overflow = '';
}

// Initialize when DOM is ready
document.addEventListener('DOMContentLoaded', function() {
    console.log('DOM Content Loaded - Initializing mobile nav');
    
    // Handle escape key globally
    document.addEventListener('keydown', function(e) {
        if (e.key === 'Escape') {
            closeMobileNav();
        }
    });
    
    // Handle window resize to close mobile menu on desktop
    window.addEventListener('resize', function() {
        if (window.innerWidth >= 992) {
            closeMobileNav();
        }
    });
    
    // Make functions globally available
    window.toggleMobileNav = toggleMobileNav;
    window.openMobileNav = openMobileNav;
    window.closeMobileNav = closeMobileNav;
    
    console.log('Mobile navigation initialized');
}); 