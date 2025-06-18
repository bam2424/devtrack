// DevTrack Site JavaScript
console.log('DevTrack site.js loaded');

// Basic mobile menu support (backup for cases where Blazor fails)
document.addEventListener('DOMContentLoaded', function() {
    console.log('DOM Content Loaded');
    
    // Handle escape key globally
    document.addEventListener('keydown', function(e) {
        if (e.key === 'Escape') {
            const sidebar = document.querySelector('.sidebar.show');
            const overlay = document.querySelector('.mobile-overlay.show');
            
            if (sidebar) {
                sidebar.classList.remove('show');
            }
            if (overlay) {
                overlay.classList.remove('show');
            }
        }
    });
    
    // Handle window resize to close mobile menu on desktop
    window.addEventListener('resize', function() {
        if (window.innerWidth >= 992) {
            const sidebar = document.querySelector('.sidebar');
            const overlay = document.querySelector('.mobile-overlay');
            
            if (sidebar) {
                sidebar.classList.remove('show');
            }
            if (overlay) {
                overlay.classList.remove('show');
            }
        }
    });
}); 